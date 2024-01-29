using Interfaces;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace MachineLearning_AI
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
    public class AI_StateControl : MonoBehaviour
    {
        [SerializeField] private float InteractionRange = 1.5f;
        [SerializeField] private LayerMask Map_Groundlayer;
        [SerializeField] private float WalkpointRange;
        [SerializeField] private float SensorTriggerAngle = 45f;
        [SerializeField] private float SensorTriggerDistance = 15f;

        private GameObject Target;
        private AICore AI;

        private bool AttackState;
        private bool InteractingState;
        private bool HasWalkpoint;
        private bool HasWeapon;
        private float Agent_WalkSpeed;
        private float Agent_RunSpeed;
        public float AttackPriority;
        private float defaultSensorAngleVal;
        private float defaultDistanceVal;
        private Vector3 Walkpoint;

        private void Start()
        {

            AI = gameObject.GetComponent<AICore>();

            Agent_WalkSpeed = AI.agent.speed;
            Agent_RunSpeed = AI.agent.speed * 2;

            defaultSensorAngleVal = AI.sensor.angle;
            defaultDistanceVal = AI.sensor.DistanceRange;

        }

        private void Update()
        {
            SearchForWalkPoint();
            SearchForHeal();
            PriorityControl();

            if(!HasWeapon)
            {CheckWeapon();}
            else
            { AddWeapon();}

            if (AI.weapon != null && AI.sensor != null && AI.health != null)
            {
                if(TargetDetected() && !HasWeapon && AttackPriority > 0.2f)//check if target in sight and if ai has a weapon
                {
                    // Melee Attack
                    AttackState = true;
                    AI.weapon.MeleeAttack(Target.transform);
                }

                if(TargetDetected() && HasWeapon && AttackPriority > 0.2f)//Checks if there is a target and can attack;
                {
                    // Weapon Attack

                    AttackState = true;
                    AI.sensor.angle = SensorTriggerAngle;
                    AI.sensor.DistanceRange = SensorTriggerDistance;
                    AI.agent.speed = Agent_RunSpeed;
                    HasWeapon = false;
                    AttackTarget();
                }
                else if (AttackPriority <= 0.2f)
                {
                    Retreat();
                }
                else
                {
                    AI.sensor.angle = defaultSensorAngleVal;
                    AI.sensor.DistanceRange = defaultDistanceVal;
                    AI.agent.speed = Agent_WalkSpeed;
                    AttackState = false;
                }
            }

   

        }

        private void CheckWeapon()
        {
            if (AI.weapon != null)
            {
                if (AI.weapon.GetWeapon != null)
                {
                    HasWeapon = true;
                }
                else
                {
                    GameObject FindWeapon = FindPickUp();
                    if (FindWeapon != null)
                    {
                        AI.weapon.WeaponObtained(FindWeapon);
                        HasWeapon = true;
                    }
                    else
                    {
                        HasWeapon = false;
                    }
                }
            }
        }// Checks if the Ai has a weapon to attack 

        private void AttackTarget()
        {
            // Attacks the Target
            
            AI.weapon.Attack_Target(Target.transform);

        }

        private void PriorityControl()
        {
            if(AI.health != null)// validate the component
            {
                // Allows the AI to Retreat if their health is below 20%
                float Health_Percentage = (AI.health.GetHealth / AI.health.Max_Health);
                AttackPriority = Mathf.Clamp(Health_Percentage, 0, 1);

                if (Health_Percentage < 0.2f)
                {
                    AttackPriority = Health_Percentage;
                }
                else
                {
                    AttackPriority = Health_Percentage;
                }
                Debug.Log("Attack Priority: " + AttackPriority);

                //Can Add As Much priority functions as needed
            }
        } // Can Add more priority

        private void Retreat()
        {
            AI.agent.speed = Agent_RunSpeed;
            HasWalkpoint = false;
        }// in development

        private void SearchForWalkPoint()
        {
            if(!AttackState && !InteractingState && !HasWalkpoint)
            {
                Vector3 currentLocation = gameObject.transform.position;
                float Rand_X = Random.Range(-WalkpointRange, WalkpointRange);
                float Rand_Z = Random.Range(-WalkpointRange, WalkpointRange);

                Walkpoint = new Vector3(currentLocation.x + Rand_X, currentLocation.y, currentLocation.z + Rand_Z);

                if (Physics.Raycast(Walkpoint, -transform.up, 2f, Map_Groundlayer))
                {
                    HasWalkpoint = true;
                }
            }

            if(!AttackState && !InteractingState && HasWalkpoint)
            {
                AI.agent.SetDestination(Walkpoint);

                if(AI.agent.remainingDistance < 1f)
                {
                    HasWalkpoint  = false;
                }
            }

        }//Completed

        private bool TargetDetected()
        {
            if(AI.sensor != null)
            {
                if(AI.sensor.ObjectFound.Count > 0)
                {
                    foreach(GameObject target in AI.sensor.ObjectFound)
                    {
                        if (target.CompareTag("Target"))
                        {
                            Target = target;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        } // Completed

        private GameObject FindPickUp()
        {
            if(AI.sensor.ObjectFound.Count > 0)
            {
                foreach (GameObject obj in AI.sensor.ObjectFound)
                {
                    if (obj.GetComponent<IAttactable>() != null && obj.GetComponent<IPickable>() != null)
                    {
                        AI.agent.SetDestination(AI.sensor.ObjectFound[0].transform.position);

                        if(AI.agent.remainingDistance < InteractionRange)
                        {
                            Debug.Log("Weapon " + obj.name +" Found");
                            GameObject weapon = AI.sensor.ObjectFound[0];
                            obj.GetComponent<IPickable>().PickUp();
                            AI.sensor.RemoveItem(AI.sensor.ObjectFound[0]);
                            return weapon;
                        }
                    }break;
                }
            }
            return null;
        }// Completed

        private void AddWeapon()
        {
            // comming soon
            
        }

        private void SearchForHeal()
        {
            if (AI.health.NeedHealing && AI.sensor != null && !AI.health.HealingInProgress)
            {
                if (AI.sensor.ObjectFound.Count > 0)
                {
                    bool CanResume = false;

                    foreach (GameObject obj in AI.sensor.ObjectFound)
                    {
                        if (obj.GetComponent<IHeable>() != null)
                        {
                            InteractingState = true;
                            Debug.Log("Heal found");
                            AI.agent.SetDestination(AI.sensor.ObjectFound[0].transform.position);

                            if (AI.agent.remainingDistance < InteractionRange)
                            {
                                AI.health.HealingInProgress = true;
                                AI.health.Healing(AI.sensor.ObjectFound[0]);
                                CanResume = true;
                                break;
                            }
                        }
                    }
                    if (CanResume)
                    {
                        InteractingState = false;
                        SearchForWalkPoint();
                    }
                }
            }
            else
            {
                SearchForWalkPoint();
            }
        } // Completed


    }
}


using UnityEngine;
using UnityEngine.AI;

namespace MachineLearning_AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AI_StateControl : MonoBehaviour, IAttactable
    {
        [SerializeField] private float InteractionRange = 1.5f;
        [SerializeField] private LayerMask Map_Groundlayer;
        [SerializeField] private float WalkpointRange;

        private AI_Sensor sensor;
        private NavMeshAgent agent;
        private AI_Health AI_health;
        private AI_Weapon AI_weapon;
        private GameObject Target;

        private bool AttackState;
        private bool InteractingState;
        private bool HasWalkpoint;
        private float Agent_WalkSpeed;
        private float Agent_RunSpeed;
        private Vector3 Walkpoint;


        public string Name()
        { return gameObject.name; }

        public bool Attack()
        {
            if(AI_weapon != null)
            {
                if (AI_weapon.GetWeapon != null)
                {
                    return true;
                }
                else
                {
                    if (FindPickUp())
                    {
                        AI_weapon.WeaponObtained(FindPickUp());
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }// Checks if the Ai has a weapon to attack 

        private void Start()
        {
            gameObject.TryGetComponent<AI_Sensor>( out sensor);// Checks if the AI has a sensor
            gameObject.TryGetComponent<AI_Health>( out AI_health);// Checks if the AI has a HealthScript
            gameObject.TryGetComponent<AI_Weapon>(out AI_weapon);// Checks if the AI has a WeaponScript
            agent = gameObject.GetComponent<NavMeshAgent>();// Gets the NavMesh of the AI;

            Agent_WalkSpeed = agent.speed;
            Agent_RunSpeed = agent.speed * 2;

        }

        private void Update()
        {
            SearchForWalkPoint();
            SearchForHeal();

            if (TargetDetected() && Attack())//Checks if there is a target and can attack;
            {
                AttackState = true;
                AttackTarget();
            }
            else { 
                agent.speed = Agent_WalkSpeed;
                AttackState = false;
            }



        }

        private void AttackTarget()
        {
            // Attacks the Target
            agent.speed = Agent_RunSpeed;
            // Need to Face Target;

            agent.SetDestination(Target.transform.position);


        }

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
                agent.SetDestination(Walkpoint);

                if(agent.remainingDistance < 1f)
                {
                    HasWalkpoint  = false;
                }
            }

        }

        private bool TargetDetected()
        {
            if(sensor != null)
            {
                if(sensor.ObjectFound.Count > 0)
                {
                    foreach(GameObject target in sensor.ObjectFound)
                    {
                        if (target.CompareTag("Player"))
                        {
                            Debug.Log("Player Found");
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
        }

        private GameObject FindPickUp()
        {
            if(sensor.ObjectFound.Count > 0)
            {
                Debug.Log(sensor.ObjectFound.Count);
                foreach (GameObject obj in sensor.ObjectFound)
                {
                    if (obj.GetComponent<IAttactable>() != null)
                    {
                        
                        agent.SetDestination(sensor.ObjectFound[0].transform.position);

                        if(agent.remainingDistance < InteractionRange)
                        {
                            Debug.Log("Weapon " + obj.name +" Found");
                            return sensor.ObjectFound[0];
                        }
                    }break;
                }
            }
            return null;
        }

        private void SearchForHeal()
        {
            if (AI_health.NeedHealing && sensor != null && !AI_health.HealingInProgress)
            {
                if (sensor.ObjectFound.Count > 0)
                {
                    bool CanResume = false;
                    Debug.Log(sensor.ObjectFound.Count);

                    foreach (GameObject obj in sensor.ObjectFound)
                    {
                        if (obj.GetComponent<IHeable>() != null)
                        {
                            InteractingState = true;
                            Debug.Log("Heal found");
                            agent.SetDestination(sensor.ObjectFound[0].transform.position);

                            if (agent.remainingDistance < InteractionRange)
                            {
                                AI_health.HealingInProgress = true;
                                AI_health.Healing(sensor.ObjectFound[0]);
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
        }


    }
}


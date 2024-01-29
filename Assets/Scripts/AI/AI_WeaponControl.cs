using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

namespace MachineLearning_AI
{
    public class AI_WeaponControl : MonoBehaviour
    {
        [SerializeField] private Transform WeaponContainer;
        [SerializeField] private float WeaponAttackRange = 8f;
        [SerializeField] private float MeleeAttackRange = 2f;

        public GameObject GetWeapon { get { return Current_Weapon; } private set { } }
        public GameObject GetPreviousWeapon { get { return Previous_Weapon; } private set { } }


        private GameObject Current_Weapon;
        private GameObject Previous_Weapon;
        private AICore AI;
        private Weapon_Scriptable WeaponDetails;
        private float ticks;
        private bool CanShoot;
        private int CurrentWeapon_Id;

        private void Start()
        {
           AI = gameObject.GetComponent<AICore>();
        }

        private void Update()
        {
            if (Current_Weapon != null)
            {
                Current_Weapon.transform.SetPositionAndRotation(WeaponContainer.position, WeaponContainer.rotation);
                Current_Weapon.transform.SetParent(WeaponContainer.transform, true);
                CurrentWeapon_Id = Current_Weapon.GetComponent<Weapon>().WeaponId;
            }

            if (WeaponDetails != null)
            {
                AttackAgain(WeaponDetails.Weapon_FireRate);
            }
            
        }

        public void SwapWeapon()
        {
            

        }

        public void WeaponObtained(GameObject weapon)
        {
            Current_Weapon = weapon;
            Debug.Log(GetWeapon);// Checks if the Gun Picked up has changed
        }

        public void DropWeapon(GameObject weapon)
        {
            AI.inventory.RemoveWeapon(weapon);
        }

        public void SwapWeapon(GameObject NewWeapon)
        {
            Previous_Weapon = Current_Weapon;
            Current_Weapon = NewWeapon;
            DropWeapon(Previous_Weapon);
        }

        public void MeleeAttack(Transform TargetPosition)
        {
            Debug.Log("Attacking Target : using Melee");
            //Give Enemy a melee weapon to attack

            AI.agent.SetDestination(TargetPosition.position);

            if (AI.agent.remainingDistance < MeleeAttackRange)
            {
                AI.agent.destination = gameObject.transform.position;
                if (WeaponDetails != null && AttackAgain(WeaponDetails.Weapon_FireRate))
                {
                    ticks = 0f;
                    // Melee Attack script here


                    Debug.Log("Target attacked by Melee weapon");
                }     
            }
        }

        private bool AttackAgain(float TimeBetweenAttack )
        {
            if (ticks < TimeBetweenAttack)
            {
                ticks += Time.deltaTime;
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Attack_Target(Transform TargetPosition)
        {
            if(Current_Weapon != null)
            {
                WeaponContainer.transform.LookAt(TargetPosition.position);
                AI.agent.SetDestination(TargetPosition.position);
                if (AI.agent.remainingDistance < WeaponAttackRange)
                {
                    AI.agent.destination = gameObject.transform.position;

                    WeaponDetails = Current_Weapon.GetComponent<Weapon>().GetWeaponDetails;

                    if(WeaponDetails != null && AttackAgain(WeaponDetails.Weapon_FireRate))
                    {
                        ticks = 0f;
                        Current_Weapon.GetComponent<Weapon>().Attack(TargetPosition);
                    }
                    Debug.Log("Attacking Target : using Weapon-" + Current_Weapon.name);
                }
            }
        }
    }
}


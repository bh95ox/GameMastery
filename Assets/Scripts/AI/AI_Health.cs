using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MachineLearning_AI;

namespace MachineLearning_AI
{
    [RequireComponent(typeof(AI_StateControl))]
    public class AI_Health : MonoBehaviour, IDamageble
    {
        [SerializeField] private float Max_Health = 100;
        [SerializeField] private float HealingRate;

        public bool NeedHealing;
        public bool HealingInProgress;
        public float GetHealth { get { return Health; } private set { } }

        //private AI_StateControl StateControl;
        private AI_Sensor sensor;
        public float Health;
        private bool Alive;

        private void Start()
        {
            //gameObject.TryGetComponent<AI_StateControl>(out StateControl);
            TryGetComponent<AI_Sensor>(out sensor);
            Health = Max_Health;
            Alive = true;
        }

        private void Update()
        {
            CheckHealthStatus();
        }

        public string GetObjectName()
        {
            return gameObject.name;
        }

        public void TakeDamage(float amount)
        {
            Debug.Log(" Damage taken health: " + Health);
            Health -= amount;
        }

        public void Healing(GameObject HealingObject)
        {
            Debug.Log("Healing");
            Heal_Scriptable HealItemdata = HealingObject.GetComponent<IHeable>().Heal();
            float HealDuration = HealItemdata.Duration;

            if (HealItemdata.InstaHeal)
            {
                Health += HealItemdata.TotalHeal;
            }
            else
            {
                while(HealDuration > 0)
                {
                    HealDuration -= Time.deltaTime;
                    Health += HealItemdata.Heal_Rate * Time.deltaTime;
                }
            }

            HealingInProgress = false;
            //HealingObject.SetActive(false);
            sensor.RemoveItem(HealingObject);
            Destroy(HealingObject);
            Debug.Log("Healing Done");
        }

        private void CheckHealthStatus()
        {
            if (Health > 0)
            {
                Alive = true;
            }
            else
            {
                Alive = false;
            }

            if (Alive && Health < Max_Health)
            {
                NeedHealing = true;
            }
            else
            {
                NeedHealing = false;
            }

            if (Health >= Max_Health)
            {
                Health = Max_Health;
            }
        }

    }
}




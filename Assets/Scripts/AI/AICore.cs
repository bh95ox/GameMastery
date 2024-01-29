using MachineLearning_AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MachineLearning_AI
{
    public class AICore : MonoBehaviour
    {
        [HideInInspector] public AI_Health health;
        [HideInInspector] public AI_Sensor sensor;
        [HideInInspector] public AI_StateControl stateControl;
        [HideInInspector] public AI_WeaponControl weapon;
        [HideInInspector] public AI_Inventory inventory;
        [HideInInspector] public NavMeshAgent agent;

        private void Awake()
        {
            gameObject.TryGetComponent<AI_Health>(out health);
            gameObject.TryGetComponent<AI_Sensor>(out sensor);
            gameObject.TryGetComponent<AI_StateControl>(out stateControl);
            gameObject.TryGetComponent<AI_WeaponControl>(out weapon);
            gameObject.TryGetComponent<NavMeshAgent>(out agent);
            gameObject.TryGetComponent<AI_Inventory>(out inventory);
        }

        public void CustomeComponent()
        {
            Debug.Log("Customer Component ");
        }
    }
}



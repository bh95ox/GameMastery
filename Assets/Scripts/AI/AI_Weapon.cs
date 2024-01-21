using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MachineLearning_AI
{
    public class AI_Weapon : MonoBehaviour
    {
        public GameObject GetWeapon { get { return Weapon_AI; } private set { } }

        private GameObject Weapon_AI;

        public GameObject Weapon_Weapon;

        private void Start()
        {
            Weapon_AI = Weapon_Weapon;
        }

        public void WeaponObtained(GameObject weapon)
        {
            Weapon_AI = weapon;
        }
    }
}


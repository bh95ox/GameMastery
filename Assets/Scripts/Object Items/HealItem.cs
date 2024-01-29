using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour,IHeable
{
    [SerializeField] private Heal_Scriptable heal_Properties;

    public Heal_Scriptable Heal()
    {
        return heal_Properties;
    }

}

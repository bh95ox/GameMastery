using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu()]
public class Weapon_Scriptable : ScriptableObject
{
    public string Weapon_Name;
    public string Weapon_Type;
    public string Weapon_Description;
    public float Weapon_MaxDamage;
    public float Weapon_MinDamage;
    public int Weapon_Price;
    public Sprite Weapon_UI_ICON;
    public GameObject Weappon_Prefab;

}

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
    public string Weapon_BulletType;
    public float Weapon_FireRate;
    public float Weapon_Damage;
    public int Weapon_Price;
    public Sprite Weapon_UI_ICON;
    public GameObject Weappon_Prefab;
    public GameObject Bullet_Prefab;

}

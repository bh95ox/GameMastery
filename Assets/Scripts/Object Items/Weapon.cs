using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Managers;

[RequireComponent(typeof(CapsuleCollider))]
public class Weapon : MonoBehaviour, IPickable, IAttactable
{
    [SerializeField] private Weapon_Scriptable Weapon_Data;
    [SerializeField] private Transform AttackPosition;
    [SerializeField] private float Rotation_Speed;
    [SerializeField] private float BulletForce = 50f;

    public Weapon_Scriptable GetWeaponDetails { get { return Weapon_Data; } private set { } }
    public int WeaponId;
    private InventoryManager inventory;

    public bool Picked; 

    private void Start()
    {
        gameObject.isStatic = true;
        inventory = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
        Picked = false;
    }

    private void Update()
    {
        if(!Picked)
        {
            transform.Rotate( 0f , Rotation_Speed * Time.deltaTime,0f, Space.Self);
            gameObject.GetComponent<Collider>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }

    }

    public string GetDescription()
    {
        return "Pick up "+ Weapon_Data.Weapon_Name;
    }

    public void PickUp()
    {
        Picked = true;
        Picked = true;
    }

    public void Attack(Transform targetPosition)
    {
        GameObject Bullet = Instantiate(Weapon_Data.Bullet_Prefab, AttackPosition.position, AttackPosition.rotation);
        BulletsProjectile B_Projectile =  Bullet.GetComponent<BulletsProjectile>();
        Bullet.GetComponent<Rigidbody>().AddForce(BulletForce * AttackPosition.forward, ForceMode.Impulse);

        //AI has Unlimited Bullets Currently 
        // Need to set an inventory for AI  and Player to manage Items

        if (Weapon_Data.Weapon_BulletType == "Heavy")
        {
            B_Projectile.DamageAmount = Weapon_Data.Weapon_Damage;
            // Can Add a Function to Reduce Bullet Count When an Inventory is establish for AI
        }
        else if(Weapon_Data.Weapon_BulletType == "Medium")
        {
            B_Projectile.DamageAmount = Weapon_Data.Weapon_Damage;
            // Can Add a Function to Reduce Bullet Count When an Inventory is establish for AI
        }
        else if (Weapon_Data.Weapon_BulletType == "Small")
        {
            B_Projectile.DamageAmount = Weapon_Data.Weapon_Damage;
            // Can Add a Function to Reduce Bullet Count When an Inventory is establish for AI
        }
        else
        {
            Debug.LogWarning("Bullet Type :" + Weapon_Data.Weapon_BulletType + " Not Identified !");
        }

        Debug.Log("Shooting Target");
    }

    public string Name()
    {
        return Weapon_Data.Weapon_Name;
    }

}

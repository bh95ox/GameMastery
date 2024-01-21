using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Managers;

public class Weapon : MonoBehaviour, IPickable
{
    [SerializeField] private Weapon_Scriptable Weapon_Data;
    [SerializeField] private float Rotation_Speed;

    private InventoryManager inventory;
    private bool Picked; 

    private void Start()
    {
        inventory = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
        Picked = false;
    }

    private void Update()
    {
        if(!Picked)
        {
            transform.Rotate( 0 ,0 , Rotation_Speed * Time.deltaTime, Space.Self);
        }

    }

    public string GetDescription()
    {
        return "Pick up "+ Weapon_Data.Weapon_Name;
    }

    public void PickUp()
    {
        inventory.PickUpWeapon(Weapon_Data);
        Picked = true;
        Destroy(gameObject);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Inventory : MonoBehaviour
{
    [SerializeField] int MaxWeapon_Inventoryslot;
    [SerializeField] int MaxItem_Inventory;
    [SerializeField] int MaxHeal_Inventory;

    public Transform WeaponContainer;
    public List<GameObject> GetWeapon_Inventory { get { return Weapon_Inventory; } private set { } }
    public int[] GetWeaponId { get { return WeaponID;} private set { } }

    private int MaxSmallBullet_Inv;
    private int MaxMediumBullet_Inv;
    private int MaxHeavyBullet_Inv;

    private int[] WeaponID;

    private bool canAdd;

    private List<GameObject> Weapon_Inventory;
    private Dictionary<int, GameObject> ItemInventory;
    private List<GameObject> Heal_Inventory;



    private void Update()
    {
        
        if(WeaponContainer != null && WeaponContainer.childCount > 0)
        {
            for(int i = 0; i < WeaponContainer.childCount; i++)
            {
                WeaponID[i] = i;
            }
        }
    }

    public bool CanPickUpWeapon()
    {
        if (Weapon_Inventory.Count < MaxWeapon_Inventoryslot)
        { return true; }
        else { return false;}
    }

    public bool CanPickUpHeal()
    {
        if (Heal_Inventory.Count < MaxHeal_Inventory)
        { return true; }
        else { return false; }
    }


    //public bool CanPickUpItem()
    //{
    //
    //}

    

    public void AddWeapon(GameObject weapon)
    {
        Weapon_Inventory.Add(weapon);
    }

    public void AddItem(GameObject item)
    {
       // Item_Inventory.Add(item);
    }

    public void AddHeal(GameObject Heal)
    {
        Heal_Inventory.Add(Heal);
    }

    public void RemoveWeapon(GameObject weapon)
    {
        if (Weapon_Inventory.Contains(weapon))
        {
            Weapon_Inventory.Remove(weapon);
            weapon.transform.SetParent(WeaponContainer, false);
            Vector3 currentLocation = gameObject.transform.position;
            float Rand_X = Random.Range(-2, 2);
            float Rand_Z = Random.Range(-2, 2);
            weapon.transform.position = new Vector3(currentLocation.x + Rand_X, currentLocation.y, currentLocation.z + Rand_Z);
            weapon.GetComponent<Weapon>().Picked = false;
        }
        else
        {
            Debug.Log("weapon Not found");
        }
    }

    public void UseItem()
    {
        // In Development No Items Yet;
        Debug.Log("In Development No Items Yet;");
    }

    public void UseHeal()
    {
        // In Development No Heals Yet;
        Debug.Log("In Development No Heals Yet;");
    }

}

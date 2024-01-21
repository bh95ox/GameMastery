using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;
using Scriptable_Obj;
using Managers;

public class Item : MonoBehaviour, IPickable,IHeable
{
    [SerializeField] private Item_Scriptable item_data;
    [SerializeField] private Heal_Scriptable heal_Properties;
    private InventoryManager inventory;

    private void Start()
    {
        inventory = GameObject.FindWithTag("InventoryManager").GetComponent<InventoryManager>();
    }

    public string GetDescription()
    {
       return item_data.Item_Name;
    }

    public void PickUp()
    {
        inventory.AddItem(item_data);
        Destroy(gameObject);
    }

    public Heal_Scriptable Heal()
    {
        return heal_Properties;
    }
}

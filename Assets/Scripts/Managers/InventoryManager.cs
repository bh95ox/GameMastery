using Scriptable_Obj;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class InventoryManager : MonoBehaviour
    {
        private Dictionary<Item_Scriptable, InventoryItem> Item_Dict;
        public List<InventoryItem> Inventory { get; private set; }
        public List<Weapon_Scriptable> Weapons = new List<Weapon_Scriptable>();
        public int CurrentWeaponIndex;

        void Awake()
        {
            Inventory = new List<InventoryItem>();
            Item_Dict = new Dictionary<Item_Scriptable, InventoryItem>();
        }

        public InventoryItem Get(Item_Scriptable item_ref)
        {
            if (Item_Dict.TryGetValue(item_ref, out InventoryItem value))
            {
                return value;
            }
            return null;
        }

        public void AddItem(Item_Scriptable Item_Ref)
        {
            if (Item_Dict.TryGetValue(Item_Ref, out InventoryItem item))
            {
                item.AddToStack();
            }
            else
            {
                InventoryItem newItem = new InventoryItem(Item_Ref);
                Inventory.Add(newItem);
                Item_Dict.Add(Item_Ref, newItem);
            }
        }

        public void RemoveItem(Item_Scriptable Item_Ref)
        {
            if (Item_Dict.TryGetValue(Item_Ref, out InventoryItem item))
            {
                item.RemoveFromStack();

                if (item.StackSize == 0)
                {
                    Inventory.Remove(item);
                    Item_Dict.Remove(Item_Ref);
                }

            }
        }

        public void PickUpWeapon(Weapon_Scriptable Weapon_ref)
        {
            if (Weapons.Count < 3 && !Weapons.Contains(Weapon_ref))
            {
                Weapons.Add(Weapon_ref);
            }
            else
            {
                DropWeapon(Weapons[CurrentWeaponIndex]);
                Weapons.Add(Weapon_ref);
            }

        }

        public void DropWeapon(Weapon_Scriptable Weapon_ref)
        {
            if(Weapons.Contains(Weapon_ref))
            {
                Weapons.Remove(Weapons[CurrentWeaponIndex]);
            }
            else
            {
                Debug.Log("Weapon Not Found");
            }
            Debug.Log("Item Dropped");
        }
    }
}


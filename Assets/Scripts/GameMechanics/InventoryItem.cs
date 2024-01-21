using Scriptable_Obj;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public Item_Scriptable Item_Data {  get; private set; }
    public int StackSize {  get; private set; }

    public InventoryItem(Item_Scriptable item_data)
    {
        Item_Data = item_data;
        AddToStack();
    }

    public void AddToStack()
    {
        StackSize++;
    }

    public void RemoveFromStack()
    {
        StackSize--;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scriptable_Obj
{
    [CreateAssetMenu]
    public class Item_Scriptable : ScriptableObject
    {
        public string Item_Name;
        public string Item_Type;
        public string Item_Description;
        public int Item_amount;
        public int Item_price;
        public int Item_FX;
        public Sprite Item_Icon;
        public GameObject Item_Prefab;
    }
}



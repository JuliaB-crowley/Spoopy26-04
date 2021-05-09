using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace items
{
    public enum ItemType { Heal, MaxPlus, Flash, Strengh }
    [CreateAssetMenu(fileName = "newItem", menuName = "Julia/Item", order = 0)]
    public class JUB_ItemScriptableObject : ScriptableObject
    {
        public Sprite itemSprite;
        public string itemName, itemDescription;
        public int itemPrice;
        public ItemType itemType;
        public int strengh;
    }
}

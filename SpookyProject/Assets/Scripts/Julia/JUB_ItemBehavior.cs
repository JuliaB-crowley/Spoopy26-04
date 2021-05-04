using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

namespace items
{


    public class JUB_ItemBehavior : MonoBehaviour
    {
        public JUB_Maeve maeve;
        public JUB_ItemScriptableObject scriptableObject;
        private void Awake()
        {
            maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        }
        public void ApplyEffect()
        {
            switch(scriptableObject.itemType)
            {
                case ItemType.Flash:
                    break;

                case ItemType.Heal:
                    maeve.Heal(scriptableObject.strengh);
                    break;

                case ItemType.MaxPlus:
                    maeve.MaxUpgrades(scriptableObject.strengh);
                    break;

                case ItemType.Strengh:
                    maeve.attackDamage += 1;
                    break;
            }
        }
    }
}

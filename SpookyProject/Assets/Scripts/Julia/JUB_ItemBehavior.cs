using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

namespace items
{


    public class JUB_ItemBehavior : MonoBehaviour
    {
        public JUB_Maeve maeve;
        public JUB_Flash flash;
        public JUB_ItemScriptableObject scriptableObject;
        private void Awake()
        {
            maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
            flash = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Flash>();
        }
        public void ApplyEffect()
        {
            Debug.Log(scriptableObject.itemType);
            switch(scriptableObject.itemType)
            {
                case ItemType.Flash:
                    FindObjectOfType<AudioManager>().Play("Potion");
                    flash.flashTime *= 2;
                    break;

                case ItemType.Heal:
                    FindObjectOfType<AudioManager>().Play("Coeur");
                    maeve.Heal(scriptableObject.strengh);
                    break;

                case ItemType.MaxPlus:
                    FindObjectOfType<AudioManager>().Play("Potion");
                    maeve.MaxUpgrades(scriptableObject.strengh);
                    break;

                case ItemType.Strengh:
                    FindObjectOfType<AudioManager>().Play("Potion");
                    maeve.attackDamage += 1;
                    break;
            }
        }
    }
}

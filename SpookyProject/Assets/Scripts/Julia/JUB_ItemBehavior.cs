using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;
using combat;

namespace items
{


    public class JUB_ItemBehavior : MonoBehaviour
    {
        public JUB_Maeve maeve;
        public JUB_Flash flash;
        public JUB_Combat combat;
        public JUB_ItemScriptableObject scriptableObject;
        private void Awake()
        {
            maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
            flash = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Flash>();
        }
        public void ApplyEffect()
        {
            Debug.LogWarning(scriptableObject.itemType);
            if(scriptableObject.itemType == ItemType.Strengh)
            {
                Debug.LogWarning("potion achetée");
                Debug.LogWarning(maeve.quickAttack.atkDamage);
                maeve.quickAttack.ChangeDamage(1);
                /*maeve.quickDamage += 1; JUGEZ PAS C LA PLS
                maeve.heavyDamage += 1;
                maeve.quickAttack = new JUB_Combat.AttackProfile(maeve.quickDamage, new Vector2(1, 1), 0.4f, 0.2f, "quick");
                maeve.heavyAttack = new JUB_Combat.AttackProfile(maeve.heavyDamage, new Vector2(2, 1), 0.4f, 0.8f, "heavy");*/
                Debug.LogWarning(maeve.quickAttack.atkDamage);
                FindObjectOfType<AudioManager>().Play("Potion");
            }
            switch(scriptableObject.itemType)
            {
                
                case ItemType.Flash:
                    FindObjectOfType<AudioManager>().Play("Potion");
                    flash.flashTime *= 1.2f;
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

                    break;
            }
        }
    }
}

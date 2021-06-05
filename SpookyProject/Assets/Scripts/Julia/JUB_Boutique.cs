using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using character;
using items;

public class JUB_Boutique : MonoBehaviour
{
    //ouverture
    public JUB_InteractibleBehavior interactibleBehavior;
    public GameObject canvasRescale, papaAll;
    public bool isOpen;
    public JUB_Maeve maeve;
    public JUB_Flash flash;

    //objets
    public Image[] objectSlot;
    public int[] objectPrice;
    public Text[] objectPriceDisplay;
    public JUB_ItemBehavior[] items;
  

    //confirmation
    public GameObject confirmationRescale;
    public Text confirmationText;
    Color confirmationColor;

    //buttons
    int buttonNumber;
    public GameObject[] soldText;
    public Button[] buttons;

    // Start is called before the first frame update
    void Start()
    {
        interactibleBehavior = GetComponentInChildren<JUB_InteractibleBehavior>();
        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        flash = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Flash>();
        

        for(int i = 0; i < items.Length; i++) 
        {
            objectPriceDisplay[i].text = items[i].scriptableObject.itemPrice.ToString();
            objectSlot[i].sprite = items[i].scriptableObject.itemSprite;
            //objectDescription[i].text = items[i].scriptableObject.itemDescription;
            soldText[i].SetActive(false);
        }

        confirmationColor = confirmationText.color;
        confirmationRescale.SetActive(false);
        papaAll.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(interactibleBehavior.interacted && isOpen == false)
        {
            papaAll.SetActive(true);
            confirmationRescale.SetActive(false);

            isOpen = true;
            Time.timeScale = 0f;
            interactibleBehavior.interacted = false;
        }
        if(interactibleBehavior.interacted && isOpen == true)
        {
            isOpen = false;
            Time.timeScale = 1f;
            interactibleBehavior.interacted = false;
            papaAll.SetActive(false);
        }
    }

    public void ConfirmationStart(int buttonNumberHit)
    {
        confirmationRescale.SetActive(true);
        confirmationText.color = confirmationColor;
        confirmationText.text = "Cet objet coûte " + items[buttonNumberHit].scriptableObject.itemPrice.ToString() + " bonbons. Voulez-vous l'acheter ?";
        buttonNumber = buttonNumberHit;
    }

    public void Buy()
    {
        if(maeve.currentBonbons >= items[buttonNumber].scriptableObject.itemPrice)
        {
            maeve.Achat(items[buttonNumber].scriptableObject.itemPrice);
            //Debug.Log(items[buttonNumber].scriptableObject.itemType);
            ApplyEffect();
            soldText[buttonNumber].SetActive(true);
            buttons[buttonNumber].enabled = false;
            confirmationRescale.SetActive(false);

        }
        else
        {
            confirmationText.color = Color.red;
        }

    }

    public void ApplyEffect()
    {
        //Debug.Log(items[buttonNumber].scriptableObject.itemType);
        switch (items[buttonNumber].scriptableObject.itemType)
        {
            case ItemType.Flash:
                FindObjectOfType<AudioManager>().Play("Potion");
                flash.flashTime *= 1.2f;
                break;

            case ItemType.Heal:
                FindObjectOfType<AudioManager>().Play("Coeur");
                maeve.Heal(items[buttonNumber].scriptableObject.strengh);
                break;

            case ItemType.MaxPlus:
                FindObjectOfType<AudioManager>().Play("Potion");
                maeve.MaxUpgrades(items[buttonNumber].scriptableObject.strengh);
                break;

            case ItemType.Strengh:
                FindObjectOfType<AudioManager>().Play("Potion");
                //Debug.LogWarning("potion achetée");
                //Debug.LogWarning(maeve.quickAttack.atkDamage);
                maeve.heavyAttack.ChangeDamage(1);
                maeve.quickAttack.ChangeDamage(1);
                /*maeve.quickDamage += 1; JUGEZ PAS C LA PLS
                maeve.heavyDamage += 1;
                maeve.quickAttack = new JUB_Combat.AttackProfile(maeve.quickDamage, new Vector2(1, 1), 0.4f, 0.2f, "quick");
                maeve.heavyAttack = new JUB_Combat.AttackProfile(maeve.heavyDamage, new Vector2(2, 1), 0.4f, 0.8f, "heavy");*/
                //Debug.LogWarning(maeve.quickAttack.atkDamage);
                break;
        }
    }

    public void Cancel()
    {
        confirmationRescale.SetActive(false);
    }
}

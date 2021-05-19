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
    public GameObject canvasRescale;
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
        canvasRescale.GetComponent<Transform>().localScale = Vector3.zero;
        confirmationRescale.GetComponent<Transform>().localScale = Vector3.zero;

        for(int i = 0; i < items.Length; i++) 
        {
            objectPriceDisplay[i].text = items[i].scriptableObject.itemPrice.ToString();
            objectSlot[i].sprite = items[i].scriptableObject.itemSprite;
            //objectDescription[i].text = items[i].scriptableObject.itemDescription;
            soldText[i].SetActive(false);
        }

        confirmationColor = confirmationText.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactibleBehavior.interacted && isOpen == false)
        {
            canvasRescale.GetComponent<Transform>().localScale = Vector3.one;
            isOpen = true;
            Time.timeScale = 0f;
            interactibleBehavior.interacted = false;
        }
        if(interactibleBehavior.interacted && isOpen == true)
        {
            canvasRescale.GetComponent<Transform>().localScale = Vector3.zero;
            isOpen = false;
            Time.timeScale = 1f;
            interactibleBehavior.interacted = false;
        }
    }

    public void ConfirmationStart(int buttonNumberHit)
    {
        confirmationRescale.GetComponent<Transform>().localScale = Vector3.one;
        confirmationText.color = confirmationColor;
        confirmationText.text = "Cet objet co�te " + items[buttonNumberHit].scriptableObject.itemPrice.ToString() + " bonbons. Voulez-vous l'acheter ?";
        buttonNumber = buttonNumberHit;
    }

    public void Buy()
    {
        if(maeve.currentBonbons > items[buttonNumber].scriptableObject.itemPrice)
        {
            maeve.Achat(items[buttonNumber].scriptableObject.itemPrice);
            Debug.Log(items[buttonNumber].scriptableObject.itemType);
            ApplyEffect();
            soldText[buttonNumber].SetActive(true);
            buttons[buttonNumber].enabled = false;
            confirmationRescale.GetComponent<Transform>().localScale = Vector3.zero;

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
                flash.flashTime *= 2;
                break;

            case ItemType.Heal:
                maeve.Heal(items[buttonNumber].scriptableObject.strengh);
                break;

            case ItemType.MaxPlus:
                maeve.MaxUpgrades(items[buttonNumber].scriptableObject.strengh);
                break;

            case ItemType.Strengh:
                maeve.attackDamage += 1;
                break;
        }
    }

    public void Cancel()
    {
        confirmationRescale.GetComponent<Transform>().localScale = Vector3.zero;
    }
}
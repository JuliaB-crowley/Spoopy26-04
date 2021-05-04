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

    //objets
    public Image[] objectSlot;
    public int[] objectPrice;
    public Text[] objectPriceDisplay;
    public JUB_ItemBehavior[] items;
  

    //confirmation
    public GameObject confirmationRescale;
    public Text confirmationText;

    //buttons
    public int buttonNumber;

    // Start is called before the first frame update
    void Start()
    {
        interactibleBehavior = GetComponentInChildren<JUB_InteractibleBehavior>();
        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        canvasRescale.GetComponent<Transform>().localScale = Vector3.zero;
        confirmationRescale.GetComponent<Transform>().localScale = Vector3.zero;

        for(int i = 0; i < items.Length; i++) 
        {
            objectPriceDisplay[i].text = items[i].scriptableObject.itemPrice.ToString();
            objectSlot[i].sprite = items[i].scriptableObject.itemSprite;
            //objectDescription[i].text = items[i].scriptableObject.itemDescription;
        }
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
        confirmationText.text = "This item costs " + items[buttonNumberHit].scriptableObject.itemPrice.ToString() + " sweets. Do you want to buy it ?";
        buttonNumber = buttonNumberHit;
    }

    public void Buy()
    {
        items[buttonNumber].ApplyEffect();
        maeve.Achat(items[buttonNumber].scriptableObject.itemPrice);
        confirmationRescale.GetComponent<Transform>().localScale = Vector3.zero;
    }

    public void Cancel()
    {
        confirmationRescale.GetComponent<Transform>().localScale = Vector3.zero;
    }
}

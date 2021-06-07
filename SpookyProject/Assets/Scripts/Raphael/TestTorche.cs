using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TestTorche : MonoBehaviour
{
    public bool isLit = false, hasBeenBurned = false; //Bool qui d�termine si la torche est active ou pas
    public SpriteRenderer spriteRenderer; //Sprite Renderer de la torche
    [SerializeField] GameObject flameObject;
    [SerializeField] RPP_SubPuzzleManager torchesManager; //Script qui g�re les puzzles des torches
    public bool isPartOfAPuzzle = false, hasBeenUsed = false;

    //flash manager � mettre en enfant et sur layer flashable
    public JUB_FlashManager flashManager;

    private void Start()
    {
        //torchTransform = GetComponent<Transform>();
        torchesManager = GetComponentInParent<RPP_SubPuzzleManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flashManager = GetComponent<JUB_FlashManager>();

        if (!isLit)
        {
            flameObject.SetActive(false);
        }
        else
        {
            flameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (flashManager.burned && !hasBeenBurned)
        {
            hasBeenBurned = true;
            LitTorch();
        }
    }

    void LitTorch()
    {
        isLit = true;
        flameObject.SetActive(true);
        if (!isPartOfAPuzzle)
        {
            torchesManager.successesAchieved++;
        }
        FindObjectOfType<AudioManager>().Play("Torche");
    }

    //Cette m�thode ne doit pas �tre utilis� si la torche peut �tre boug�e
    public void UnlitTorch()
    {
        flameObject.SetActive(false);
        isLit = false;
        hasBeenBurned = false;
    }


    //Contrairement au flash qui dit � l'object d�t�ct� � s'allumer, c'est la torche elle m�me qui vas r�v�ler les objets invisibles
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLit)
        {
            if (collision.GetComponent<RPP_InvisibleInkScript>())
            {
                collision.GetComponent<RPP_InvisibleInkScript>().sprite.enabled = true;
            }
            if (collision.GetComponent<RPP_BoutonScript>())
            {
                collision.GetComponent<RPP_BoutonScript>().PermanentlyActivateButton();
            }
        }
    }

    //La torche �tein l'object en contact lorsqu'il sors de la zone ilumin�
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isLit)
        {
            if (collision.GetComponent<RPP_InvisibleInkScript>())
            {
                collision.GetComponent<RPP_InvisibleInkScript>().sprite.enabled = false;
            }
            if (collision.GetComponent<RPP_BoutonScript>())
            {
                collision.GetComponent<RPP_BoutonScript>().ResetButton();
            }
        }
    }
}

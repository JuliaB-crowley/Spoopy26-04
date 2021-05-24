using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_BoutonScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer; // Je modifie le sprite pour avoir du feedback visuel  
    [SerializeField] JUB_FlashManager flashManager; //flash manager � mettre sur layer flashable
    [SerializeField] Sprite boutonActiv�, boutonD�sactiv�; //diff�rents sprites du bouton
    [SerializeField] RPP_ButtonPuzzleMaster buttonsManager;

    public bool hasBeenFlashed = false, needAPuzzleMaster = true;

    void Start()
    {
        if (needAPuzzleMaster)
        {
            buttonsManager = GetComponentInParent<RPP_ButtonPuzzleMaster>();
        }
        spriteRenderer =GetComponent<SpriteRenderer>();
        flashManager = GetComponentInChildren<JUB_FlashManager>();
        spriteRenderer.sprite = boutonD�sactiv�;
    }

    void Update()
    {
        if (needAPuzzleMaster)
        {
            if (flashManager.flashed && !hasBeenFlashed && !buttonsManager.puzzleSolved)
            {
                StartCoroutine(ActivateButton());
            }
            if (buttonsManager.puzzleSolved)
            {
                spriteRenderer.sprite = boutonActiv�;
            }
        }
        else
        {
            if (flashManager.flashed && !hasBeenFlashed)
            {
                PermanentlyActivateButton();
            }
        }
    }

    IEnumerator ActivateButton()
    {
        spriteRenderer.sprite = boutonActiv�;
        hasBeenFlashed = true;
        buttonsManager.buttonsActive++;
        yield return new WaitForSeconds(flashManager.flashTime);
        spriteRenderer.sprite = boutonD�sactiv�;
        hasBeenFlashed = false;
        buttonsManager.buttonsActive--;
    }

    public void ResetButton()
    {
        spriteRenderer.sprite = boutonD�sactiv�;
        hasBeenFlashed = false;
        if (needAPuzzleMaster)
        {
            buttonsManager.buttonsActive--;
        }
    }

    public void PermanentlyActivateButton()
    {
        spriteRenderer.sprite = boutonActiv�;
        hasBeenFlashed = true;
        if (needAPuzzleMaster)
        {
            buttonsManager.buttonsActive++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_BoutonScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer; // Je modifie le sprite pour avoir du feedback visuel  
    [SerializeField] JUB_FlashManager flashManager; //flash manager à mettre sur layer flashable
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
        spriteRenderer.color = Color.red;
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
                spriteRenderer.color = Color.white;
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
        spriteRenderer.color = Color.white;
        FindObjectOfType<AudioManager>().Play("Bouton");
        hasBeenFlashed = true;
        buttonsManager.buttonsActive++;
        yield return new WaitForSeconds(flashManager.flashTime);
        spriteRenderer.color = Color.red;
        hasBeenFlashed = false;
        buttonsManager.buttonsActive--;
    }

    public void ResetButton()
    {
        spriteRenderer.color = Color.red;
        hasBeenFlashed = false;
        if (needAPuzzleMaster)
        {
            buttonsManager.buttonsActive--;
        }
    }

    public void PermanentlyActivateButton()
    {
        FindObjectOfType<AudioManager>().Play("Bouton");
        spriteRenderer.color = Color.white;
        hasBeenFlashed = true;
        if (needAPuzzleMaster)
        {
            buttonsManager.buttonsActive++;
        }
    }
}

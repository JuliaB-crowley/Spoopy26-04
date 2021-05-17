using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_BoutonScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer; // Je modifie le sprite pour avoir du feedback visuel  
    [SerializeField] JUB_FlashManager flashManager; //flash manager à mettre sur layer flashable
    [SerializeField] Sprite boutonActivé, boutonDésactivé; //différents sprites du bouton
    [SerializeField] RPP_SubPuzzleManager buttonsManager;

    public bool hasBeenFlashed = false, isPartOfAPuzzle = false;

    void Start()
    {
        buttonsManager = GetComponentInParent<RPP_SubPuzzleManager>();
        spriteRenderer =GetComponent<SpriteRenderer>();
        flashManager = GetComponentInChildren<JUB_FlashManager>();
        spriteRenderer.sprite = boutonDésactivé;
    }

    void Update()
    {
        if (flashManager.flashed && !hasBeenFlashed && !buttonsManager.puzzleSolved)
        {
            if (!isPartOfAPuzzle)
            {
                StartCoroutine(ActivateButton());
            }
            else
            {
                spriteRenderer.sprite = boutonActivé;
                hasBeenFlashed = true;
            }
        }
        if (buttonsManager.puzzleSolved)
        {
            spriteRenderer.sprite = boutonActivé;
        }
    }

    IEnumerator ActivateButton()
    {
        spriteRenderer.sprite = boutonActivé;
        hasBeenFlashed = true;
        buttonsManager.successesAchieved++;
        yield return new WaitForSeconds(flashManager.flashTime);
        spriteRenderer.sprite = boutonDésactivé;
        hasBeenFlashed = false;
        buttonsManager.successesAchieved--;
    }

    public void ResetButton()
    {
        spriteRenderer.sprite = boutonDésactivé;
        hasBeenFlashed = false;
    }
}

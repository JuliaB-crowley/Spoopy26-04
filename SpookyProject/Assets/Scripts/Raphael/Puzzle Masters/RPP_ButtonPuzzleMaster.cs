using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_ButtonPuzzleMaster : MonoBehaviour
{
    [SerializeField] RPP_SubPuzzleManager buttonPuzzeManager;
    [SerializeField] RPP_BoutonScript[] buttons;
    public int totalButtonsRequired = 0, buttonsActive = 0;
    public bool puzzleSolved;
    void Start()
    {
        buttonPuzzeManager = GetComponentInParent<RPP_SubPuzzleManager>();
        foreach (RPP_BoutonScript button in buttons)
        {
            totalButtonsRequired++;
        }
    }

    void Update()
    {
        if(buttonsActive >= totalButtonsRequired)
        {
            buttonPuzzeManager.successesAchieved++;
            puzzleSolved = true;
        }
    }
}

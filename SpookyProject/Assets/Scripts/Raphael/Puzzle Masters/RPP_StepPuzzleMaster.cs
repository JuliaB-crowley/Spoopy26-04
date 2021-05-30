using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_StepPuzzleMaster : MonoBehaviour
{
    //Le script qui gère le puzzle des dalles
    public int stepsRequired; // Combien de dalles le joueur doit bien activer pour réussir
    public int currentSteps = 0; // Combien de dalles le joueur à marché
    public int correctSteps = 0; // Combien de dalles correctes le joueur à marché
    public bool playerHasFailed = false, playerHasSucceeded = false, puzzleHasBeenCompleted = false; // des bools qui checkent la progréssion du joueur dans le niveau
    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD, needPzMnE, needPzMnF, needPzMnG;
    [SerializeField] RPP_IndividualStep[] steps;

    private void Start()
    {
        if (needPzMnA)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterA").GetComponent<RPP_GeneralPuzzleMaster>();
        }
        else if (needPzMnB)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterB").GetComponent<RPP_GeneralPuzzleMaster>();
        }
        else if (needPzMnC)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterC").GetComponent<RPP_GeneralPuzzleMaster>();
        }
        else if (needPzMnD)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterD").GetComponent<RPP_GeneralPuzzleMaster>();
        }
        else if (needPzMnE)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterE").GetComponent<RPP_GeneralPuzzleMaster>();
        }
        else if (needPzMnF)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterF").GetComponent<RPP_GeneralPuzzleMaster>();
        }
        else if (needPzMnG)
        {
            puzzleMaster = GameObject.FindGameObjectWithTag("PuzzleMasterG").GetComponent<RPP_GeneralPuzzleMaster>();
        }
    }

    void Update()
    {
        if(currentSteps >= stepsRequired) //Check de tentative du joueur
        {
            if(correctSteps == stepsRequired && !puzzleHasBeenCompleted) //Le joueur à réussit
            {
                puzzleHasBeenCompleted = true;
                playerHasSucceeded = true;
                puzzleMaster.puzzlesSolved++;
                Debug.Log("The Player Has Succeeded");                
            }
            else if(correctSteps < stepsRequired) // Le joueur à échoué. Il doit sortir des dalles pour les reset puis récommencer
            {
                StartCoroutine(ResetTiles());
            }

        }
    }

    //J'ai besoin que les deux bools soyent opposés pendant quelques frames pour que je puisse reset les dalles
    IEnumerator ResetTiles()
    {       
        playerHasFailed = true;
        yield return new WaitForSeconds(0.5f);
        currentSteps = 0;
        correctSteps = 0;
        foreach (RPP_IndividualStep item in steps)
        {
            item.ResetStep();
        }
        playerHasFailed = false;
    }   
}

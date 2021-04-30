using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_SubPuzzleManager : MonoBehaviour
{
    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    public int totalSuccessesRequired, successesAchieved;
    public bool puzzleSolved = false;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD;

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
    }

    private void Update()
    {
        if (totalSuccessesRequired <= successesAchieved && !puzzleSolved)
        {
            puzzleSolved = true;
            puzzleMaster.puzzlesSolved++;
        }
    }
}

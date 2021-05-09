using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_GeneralPuzzleMaster : MonoBehaviour
{
    public int puzzlesSolved = 0;
    public bool hasBlueKey = false, hasYellowKey = false, hasGreenKey = false, hasVioletKey = false;
    public bool isPuzzleMasterA, isPuzzleMasterB, isPuzzleMasterC, isPuzzleMasterD;

    private void Awake()
    {
        if (isPuzzleMasterA)
        {
            this.tag = "PuzzleMasterA";
        }
        else if (isPuzzleMasterB)
        {
            this.tag = "PuzzleMasterB";
        }
        else if (isPuzzleMasterC)
        {
            this.tag = "PuzzleMasterC";
        }
        else if (isPuzzleMasterD)
        {
            this.tag = "PuzzleMasterD";
        }
    }
}

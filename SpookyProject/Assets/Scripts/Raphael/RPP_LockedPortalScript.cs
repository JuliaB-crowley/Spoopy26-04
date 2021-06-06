using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_LockedPortalScript : MonoBehaviour
{
    [SerializeField] JUB_TeleportationPoints teleportScript;
    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD, needPzMnE, needPzMnF, needPzMnG;
    [SerializeField] bool needBlueKey, needYellowKey, needGreenKey, needVioletKey;
    [SerializeField] GameObject portalBlock;
    public int totalKeysNeeded, keysPosessed;

    void Start()
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

        if (needBlueKey)
        {
            totalKeysNeeded++;
        }
        if(needYellowKey)
        {
            totalKeysNeeded++;
        }
        if (needGreenKey)
        {
            totalKeysNeeded++;
        }
        if (needVioletKey)
        {
            totalKeysNeeded++;
        }

        teleportScript = GetComponent<JUB_TeleportationPoints>();
        teleportScript.pointADesactivated = true;
    }

    void Update()
    {
        if(needBlueKey && puzzleMaster.hasBlueKey)
        {
            needBlueKey = false;
            keysPosessed++;
        }
        if (needGreenKey && puzzleMaster.hasGreenKey)
        {
            needGreenKey = false;
            keysPosessed++;
        }
        if (needYellowKey && puzzleMaster.hasYellowKey)
        {
            needYellowKey = false;
            keysPosessed++;
        }
        if (needVioletKey && puzzleMaster.hasVioletKey)
        {
            needVioletKey = false;
            keysPosessed++;
        }

        if(keysPosessed == totalKeysNeeded)
        {
            portalBlock.SetActive(false);
            teleportScript.pointADesactivated = false;
        }
    }
}


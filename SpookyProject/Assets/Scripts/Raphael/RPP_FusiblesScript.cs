using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_FusiblesScript : MonoBehaviour
{
    [SerializeField] JUB_InteractibleBehavior interactionManager;

    [SerializeField] SpriteRenderer blueFuse, yellowFuse, greenFuse, violetFuse;
    [SerializeField] Sprite activeBlueFuse, inactiveBlueFuse, activeYellowFuse, inactiveYellowFuse, activeGreenFuse, inactiveGreenFuse, activeVioletFuse, inactiveVioletFuse;
    public bool needsBlueFuse, needsYellowFuse, needsGreenFuse, needsVioletFuse;
    bool blueFuseActive = false, yellowFuseActive = false, greenFuseActive = false, violetFuseActive = false, retrievedFuse = false;
    [SerializeField] static bool puzzleSolved = false;
    public int totalFusesRequired, fusesAcquired;

    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD;
    void Start()
    {
        interactionManager = GetComponent<JUB_InteractibleBehavior>();
        PuzzleMasterCheck();
        ActiveFusesCheck();
    }

    void Update()
    {       
            if (interactionManager.interacted)
            {
                FusesCheck();
                interactionManager.interacted = false;
            }
            if(fusesAcquired == totalFusesRequired && !puzzleSolved)
            {
                puzzleMaster.puzzlesSolved++;
                puzzleSolved = true;
            }       
    }

    void PuzzleMasterCheck()
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

    void ActiveFusesCheck()
    {
        if (needsBlueFuse)
        {
            blueFuse.enabled = true;
            blueFuse.sprite = inactiveBlueFuse;
        }
        if (needsYellowFuse)
        {
            yellowFuse.enabled = true;
            yellowFuse.sprite = inactiveYellowFuse;
        }
        if (needsGreenFuse)
        {
            greenFuse.enabled = true;
            greenFuse.sprite = inactiveGreenFuse;
        }
        if (needsVioletFuse)
        {
            violetFuse.enabled = true;
            violetFuse.sprite = inactiveVioletFuse;
        }
    }

    void FusesCheck()
    {
        if(needsBlueFuse && puzzleMaster.hasBlueKey && !blueFuseActive)
        {
            blueFuse.sprite = activeBlueFuse;
            puzzleMaster.hasBlueKey = false;
            blueFuseActive = true;
            fusesAcquired++;
        }
        else if(needsBlueFuse && !puzzleMaster.hasBlueKey && blueFuseActive)
        {
            blueFuse.sprite = inactiveBlueFuse;
            puzzleMaster.hasBlueKey = true;
            blueFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsYellowFuse && puzzleMaster.hasYellowKey && !yellowFuseActive)
        {
            yellowFuse.sprite = activeYellowFuse;
            puzzleMaster.hasYellowKey = false;
            yellowFuseActive = true;
            fusesAcquired++;
        }
        else if (needsYellowFuse && !puzzleMaster.hasYellowKey && yellowFuseActive)
        {
            yellowFuse.sprite = inactiveYellowFuse;
            puzzleMaster.hasYellowKey = true;
            yellowFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsGreenFuse && puzzleMaster.hasGreenKey && !greenFuseActive)
        {
            greenFuse.sprite = activeGreenFuse;
            puzzleMaster.hasGreenKey = false;
            greenFuseActive = true;
            fusesAcquired++;
        }
        else if (needsGreenFuse && !puzzleMaster.hasGreenKey && greenFuseActive)
        {
            greenFuse.sprite = inactiveGreenFuse;
            puzzleMaster.hasGreenKey = true;
            greenFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsVioletFuse && puzzleMaster.hasVioletKey && !violetFuseActive)
        {
            violetFuse.sprite = activeVioletFuse;
            puzzleMaster.hasVioletKey = false;
            violetFuseActive = true;
            fusesAcquired++;
        }
        else if (needsVioletFuse && !puzzleMaster.hasVioletKey && violetFuseActive)
        {
            violetFuse.sprite = inactiveVioletFuse;
            puzzleMaster.hasVioletKey = true;
            violetFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (retrievedFuse && !puzzleSolved)
        {
            puzzleMaster.puzzlesSolved--;
            retrievedFuse = false;
        }
    }
}

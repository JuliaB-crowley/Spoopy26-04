using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_FusiblesScript : MonoBehaviour
{
    [SerializeField] JUB_InteractibleBehavior interactionManager;

    [SerializeField] SpriteRenderer blueFuse, yellowFuse, greenFuse, violetFuse;
    [SerializeField] Sprite activeBlueFuse, inactiveBlueFuse, activeYellowFuse, inactiveYellowFuse, activeGreenFuse, inactiveGreenFuse, activeVioletFuse, inactiveVioletFuse;
    public bool needsBlueFuse, needsYellowFuse, needsGreenFuse, needsVioletFuse, linkedToADoor = false;
    bool blueFuseActive = false, yellowFuseActive = false, greenFuseActive = false, violetFuseActive = false, retrievedFuse = false;
    [SerializeField] static bool puzzleSolved = false;
    public int totalFusesRequired = 0, fusesAcquired;

    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD, needPzMnE, needPzMnF, needPzMnG;
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
                InteractionCheck();
                interactionManager.interacted = false;
            }
            if(fusesAcquired == totalFusesRequired && !puzzleSolved && !linkedToADoor)
            {
                Debug.Log("the fusebox works");
                puzzleMaster.puzzlesSolved++;
                puzzleSolved = true;
                FindObjectOfType<AudioManager>().Play("EnigmeVrai");
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

    void ActiveFusesCheck()
    {
        if (needsBlueFuse)
        {
            blueFuse.enabled = true;
            blueFuse.sprite = inactiveBlueFuse;
            totalFusesRequired++;
        }
        if (needsYellowFuse)
        {
            yellowFuse.enabled = true;
            yellowFuse.sprite = inactiveYellowFuse;
            totalFusesRequired++;
        }
        if (needsGreenFuse)
        {
            greenFuse.enabled = true;
            greenFuse.sprite = inactiveGreenFuse;
            totalFusesRequired++;
        }
        if (needsVioletFuse)
        {
            violetFuse.enabled = true;
            violetFuse.sprite = inactiveVioletFuse;
            totalFusesRequired++;
        }
    }

    void InteractionCheck()
    {
        if(!puzzleMaster.hasBlueKey && !puzzleMaster.hasYellowKey && !puzzleMaster.hasGreenKey && !puzzleMaster.hasVioletKey)
        {
            RemoveFuses();
            FindObjectOfType<AudioManager>().Play("PowerDown");
        }
        else
        {
            AddFuses();
            FindObjectOfType<AudioManager>().Play("PowerUp");
        }
    }

    void RemoveFuses()
    {
        if (needsBlueFuse && blueFuseActive)
        {
            blueFuse.sprite = inactiveBlueFuse;
            puzzleMaster.hasBlueKey = true;
            blueFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsYellowFuse && yellowFuseActive)
        {
            yellowFuse.sprite = inactiveYellowFuse;
            puzzleMaster.hasYellowKey = true;
            yellowFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsGreenFuse && greenFuseActive)
        {
            greenFuse.sprite = inactiveGreenFuse;
            puzzleMaster.hasGreenKey = true;
            greenFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsVioletFuse && violetFuseActive)
        {
            violetFuse.sprite = inactiveVioletFuse;
            puzzleMaster.hasVioletKey = true;
            violetFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (retrievedFuse && !puzzleSolved && !linkedToADoor)
        {
            puzzleMaster.puzzlesSolved--;
            retrievedFuse = false;
        }
    }

    void AddFuses()
    {
        if(needsBlueFuse && puzzleMaster.hasBlueKey && !blueFuseActive)
        {
            blueFuse.sprite = activeBlueFuse;
            puzzleMaster.hasBlueKey = false;
            blueFuseActive = true;
            fusesAcquired++;
        }
        if (needsYellowFuse && puzzleMaster.hasYellowKey && !yellowFuseActive)
        {
            yellowFuse.sprite = activeYellowFuse;
            puzzleMaster.hasYellowKey = false;
            yellowFuseActive = true;
            fusesAcquired++;
        }
        if (needsGreenFuse && puzzleMaster.hasGreenKey && !greenFuseActive)
        {
            greenFuse.sprite = activeGreenFuse;
            puzzleMaster.hasGreenKey = false;
            greenFuseActive = true;
            fusesAcquired++;
        }       
        if (needsVioletFuse && puzzleMaster.hasVioletKey && !violetFuseActive)
        {
            violetFuse.sprite = activeVioletFuse;
            puzzleMaster.hasVioletKey = false;
            violetFuseActive = true;
            fusesAcquired++;
        }               
    }
}

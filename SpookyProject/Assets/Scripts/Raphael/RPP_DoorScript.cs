using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_DoorScript : MonoBehaviour
{
    [SerializeField] JUB_InteractibleBehavior doorManager;
    public GameObject doorObject;
    public int minPuzzlesSolved;
    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    [SerializeField] RPP_FusiblesScript fusiblesScript;
    public SpriteRenderer doorSprite;
    public Sprite doorOpen, doorLocked, blueDoor, yellowDoor, greenDoor, violetDoor, brokenDoor, openOneSide;
    [SerializeField] bool needBlueKey, needYellowKey, needGreenKey, needVioletKey, doorIsBroken, opensOneSide, needPzMnA = true, needPzMnB, needPzMnC, needPzMnD, needPzMnE, needPzMnF, needPzMnG, dependsOnFusebox  = false;

    void Start()
    {
        doorManager = this.GetComponent<JUB_InteractibleBehavior>();
        doorSprite = GetComponentInChildren<SpriteRenderer>();

        if (dependsOnFusebox)
        {
            doorSprite.sprite = doorLocked;
            fusiblesScript.linkedToADoor = true;
        }
        else
        {
            //Detects what kind of key it will need to be oppened
            KeyCheck();

            //Detects what Puzzle Manager the door will be associated with
            PuzzleManagerCheck();
        }      
    }

    void Update()
    {
        if (!doorIsBroken)
        {
            if (dependsOnFusebox)
            {
                if(fusiblesScript.fusesAcquired >= fusiblesScript.totalFusesRequired)
                {
                    doorObject.SetActive(false);
                }
                else
                {
                    doorSprite.sprite = doorLocked;
                    doorObject.SetActive(true);
                    doorManager.interacted = false;
                }
            }
            else if (!needBlueKey && !needYellowKey && !needGreenKey && !needVioletKey)
            {
                if (minPuzzlesSolved <= puzzleMaster.puzzlesSolved && !opensOneSide)
                {
                    doorObject.SetActive(false);
                }
                else if(minPuzzlesSolved <= puzzleMaster.puzzlesSolved && opensOneSide)
                {
                    if (!doorManager.interacted)
                    {
                        doorObject.SetActive(true);
                    }
                    else
                    {
                        doorObject.SetActive(false);
                    }
                }
                else
                {
                    doorObject.SetActive(true);
                    doorSprite.sprite = doorLocked;
                    //Debug.Log("The player has to solve a puzzle");
                }
            }
            else
            {
                if (needBlueKey)
                {
                    if (!puzzleMaster.hasBlueKey)
                    {
                        doorObject.SetActive(true);
                        doorManager.interacted = false;
                    }
                    else
                    {
                        doorObject.SetActive(false);
                    }
                }

                if (needYellowKey)
                {
                    if (!puzzleMaster.hasYellowKey)
                    {
                        doorObject.SetActive(true);
                        doorManager.interacted = false;
                    }
                    else
                    {
                        doorObject.SetActive(false);
                    }
                }

                if (needGreenKey)
                {
                    if (!puzzleMaster.hasGreenKey)
                    {
                        doorObject.SetActive(true);
                        doorManager.interacted = false;
                    }
                    else
                    {
                        doorObject.SetActive(false);
                    }

                }

                if (needVioletKey)
                {
                    if (!puzzleMaster.hasVioletKey)
                    {
                        doorObject.SetActive(true);
                        doorManager.interacted = false;
                    }
                    else
                    {
                        doorObject.SetActive(false);
                    }
                }
            }
        }
        else
        {
            doorObject.SetActive(true);
            doorManager.interacted = false;
        }
    }

    void PuzzleManagerCheck()
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
    
    void KeyCheck()
    {
        if (needBlueKey)
        {
            doorSprite.sprite = blueDoor;
        }
        else if (needYellowKey)
        {
            doorSprite.sprite = yellowDoor;
        }
        else if (needGreenKey)
        {
            doorSprite.sprite = greenDoor;
        }
        else if (needVioletKey)
        {
            doorSprite.sprite = violetDoor;
        }
        else if (doorIsBroken)
        {
            doorSprite.sprite = brokenDoor;
        }
        if (opensOneSide)
        {
            doorSprite.sprite = openOneSide;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_DoorScript : MonoBehaviour
{
    [SerializeField] JUB_InteractibleBehavior doorManager;
    //public RPP_RoomMasterScript roomMaster;
    public GameObject doorObject;
    public int minPuzzlesSolved;
    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    public SpriteRenderer doorSprite;
    public Sprite doorOpen, doorLocked, blueDoor, yellowDoor, greenDoor, violetDoor, brokenDoor;
    [SerializeField] bool needBlueKey, needYellowKey, needGreenKey, needVioletKey, doorIsBroken, needPzMnA = true, needPzMnB, needPzMnC, needPzMnD;

    void Start()
    {
        doorManager = this.GetComponent<JUB_InteractibleBehavior>();
        doorSprite = GetComponentInChildren<SpriteRenderer>();

        //Detects what kind of key it will need to be oppened
        KeyCheck();

        //Detects what Puzzle Manager the door will be associated with
        PuzzleManagerCheck();
    }

    void Update()
    {
        if (!doorIsBroken)
        {
            if (!needBlueKey && !needYellowKey && !needGreenKey && !needVioletKey)
            {
                if (minPuzzlesSolved <= puzzleMaster.puzzlesSolved)
                {
                    doorSprite.sprite = doorOpen;

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
                    doorManager.interacted = false;
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
                        doorSprite.sprite = doorOpen;

                        if (!doorManager.interacted)
                        {
                            doorObject.SetActive(true);
                        }
                        else
                        {
                            doorObject.SetActive(false);
                        }
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
                        doorSprite.sprite = doorOpen;

                        if (!doorManager.interacted)
                        {
                            doorObject.SetActive(true);
                        }
                        else
                        {
                            doorObject.SetActive(false);
                        }
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
                        doorSprite.sprite = doorOpen;

                        if (!doorManager.interacted)
                        {
                            doorObject.SetActive(true);
                        }
                        else
                        {
                            doorObject.SetActive(false);
                        }
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
                        doorSprite.sprite = doorOpen;

                        if (!doorManager.interacted)
                        {
                            doorObject.SetActive(true);
                        }
                        else
                        {
                            doorObject.SetActive(false);
                        }
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
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
    }
}

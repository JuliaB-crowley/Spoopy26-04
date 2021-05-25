using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_KeysScript : MonoBehaviour
{
    public GameObject keyObject;
    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    public bool isYellowKey, isBlueKey, isGreenKey, isVioletKey;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD, needPzMnE, needPzMnF, needPzMnG;

    void Start()
    {
        keyObject = this.gameObject;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (isYellowKey)
            {
                puzzleMaster.hasYellowKey = true;
                keyObject.SetActive(false);
            }
            else if (isBlueKey)
            {
                puzzleMaster.hasBlueKey = true;
                keyObject.SetActive(false);
            }
            else if (isGreenKey)
            {
                puzzleMaster.hasGreenKey = true;
                keyObject.SetActive(false);
            }
            else if (isVioletKey)
            {
                puzzleMaster.hasVioletKey = true;
                keyObject.SetActive(false);
            }
        }
    }
}

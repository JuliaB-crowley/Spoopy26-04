using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_FusiblesScript : MonoBehaviour
{
    [SerializeField] JUB_InteractibleBehavior interactionManager;

    [SerializeField] SpriteRenderer blueFuse, yellowFuse, greenFuse, violetFuse;
    public bool needsBlueFuse, needsYellowFuse, needsGreenFuse, needsVioletFuse, linkedToADoor = false;
    bool blueFuseActive = false, yellowFuseActive = false, greenFuseActive = false, violetFuseActive = false, retrievedFuse = false;
    [SerializeField] static bool puzzleSolved = false;
    public int totalFusesRequired = 0, fusesAcquired;
    public float blueAlpha, yellowAlpha, greenAlpha, violetAlpha;

    [SerializeField] RPP_GeneralPuzzleMaster puzzleMaster;
    [SerializeField] bool needPzMnA = true, needPzMnB, needPzMnC, needPzMnD, needPzMnE, needPzMnF, needPzMnG;
    void Start()
    {
        interactionManager = GetComponent<JUB_InteractibleBehavior>();
        PuzzleMasterCheck();
        ActiveFusesCheck();

        // Je ne sais pas pourquoi, mais je dois toucher à l'alpha de chaque un des sprites pour qu'il marchent bien
        Color currColor = blueFuse.color;
        currColor.a = blueAlpha;
        blueFuse.color = currColor;
        blueAlpha = 1f;
        currColor.a = yellowAlpha;
        yellowFuse.color = currColor;
        yellowAlpha = 1f;
        currColor.a = greenAlpha;
        greenFuse.color = currColor;
        greenAlpha = 1f;
        currColor.a = violetAlpha;
        violetFuse.color = currColor;
        violetAlpha = 1f;
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
            Color currColor = blueFuse.color;
            currColor.a = blueAlpha;            
            blueFuse.color = currColor;
            blueAlpha = 0.5f;
            totalFusesRequired++;
        }
        if (needsYellowFuse)
        {
            yellowFuse.enabled = true;
            Color currColor = yellowFuse.color;
            currColor.a = yellowAlpha;
            yellowFuse.color = currColor;
            yellowAlpha = 0.5f;
            totalFusesRequired++;
        }
        if (needsGreenFuse)
        {
            greenFuse.enabled = true;
            Color currColor = greenFuse.color;
            currColor.a = greenAlpha;
            greenFuse.color = currColor;
            greenAlpha = 0.5f;
            totalFusesRequired++;
        }
        if (needsVioletFuse)
        {
            violetFuse.enabled = true;
            Color currColor = violetFuse.color;
            currColor.a = violetAlpha;
            violetFuse.color = currColor;
            violetAlpha = 0.5f;
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
            Color currColor = blueFuse.color;
            currColor.a = blueAlpha;
            blueFuse.color = currColor;
            blueAlpha = 1f;
            //blueAlpha = 0.5f;
            puzzleMaster.hasBlueKey = true;
            blueFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsYellowFuse && yellowFuseActive)
        {
            Color currColor = yellowFuse.color;
            currColor.a = yellowAlpha;
            yellowFuse.color = currColor;
            yellowAlpha = 1f;
            //yellowAlpha = 0.5f;
            puzzleMaster.hasYellowKey = true;
            yellowFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsGreenFuse && greenFuseActive)
        {
            Color currColor = greenFuse.color;
            currColor.a = greenAlpha;
            greenFuse.color = currColor;
            greenAlpha = 1f;
            //greenAlpha = 0.5f;
            puzzleMaster.hasGreenKey = true;
            greenFuseActive = false;
            fusesAcquired--;
            puzzleSolved = false;
            retrievedFuse = true;
        }
        if (needsVioletFuse && violetFuseActive)
        {
            Color currColor = violetFuse.color;
            currColor.a = violetAlpha;
            violetFuse.color = currColor;
            violetAlpha = 1f;
            //violetAlpha = 0.5f;
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
            Color currColor = blueFuse.color;
            currColor.a = blueAlpha;
            blueFuse.color = currColor;
            //blueAlpha = 1f;
            blueAlpha = 0.5f;
            puzzleMaster.hasBlueKey = false;
            blueFuseActive = true;
            fusesAcquired++;
        }
        if (needsYellowFuse && puzzleMaster.hasYellowKey && !yellowFuseActive)
        {
            Color currColor = yellowFuse.color;
            currColor.a = yellowAlpha;
            yellowFuse.color = currColor;
            yellowAlpha = 0.5f;
            //yellowAlpha = 1f;
            puzzleMaster.hasYellowKey = false;
            yellowFuseActive = true;
            fusesAcquired++;
        }
        if (needsGreenFuse && puzzleMaster.hasGreenKey && !greenFuseActive)
        {
            Color currColor = greenFuse.color;
            currColor.a = greenAlpha;
            greenFuse.color = currColor;
            //greenAlpha = 1f;
            greenAlpha = 0.5f;
            puzzleMaster.hasGreenKey = false;
            greenFuseActive = true;
            fusesAcquired++;
        }       
        if (needsVioletFuse && puzzleMaster.hasVioletKey && !violetFuseActive)
        {
            Color currColor = violetFuse.color;
            currColor.a = violetAlpha;
            violetFuse.color = currColor;
            //violetAlpha = 1f;
            violetAlpha = 0.5f;
            puzzleMaster.hasVioletKey = false;
            violetFuseActive = true;
            fusesAcquired++;
        }               
    }
}

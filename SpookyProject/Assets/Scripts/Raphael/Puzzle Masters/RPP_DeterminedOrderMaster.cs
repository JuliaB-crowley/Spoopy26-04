using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_DeterminedOrderMaster : MonoBehaviour
{
    [SerializeField] RPP_DeterminedOrderSon[] orderChildren;
    [SerializeField] RPP_SubPuzzleManager orderPuzzeManager;
    [SerializeField] bool firstIsActive, secondIsActive, thirdIsActive, fourthIsActive, fithIsActive, sixthIsActive, seventhIsActive, eightIsActive;
    bool puzzleCompleted = false;
    [SerializeField] int tries = 0, successes = 0, successesNeeded = 0;

    private void Start()
    {
        orderPuzzeManager = GetComponentInParent<RPP_SubPuzzleManager>();
        foreach  (RPP_DeterminedOrderSon item in orderChildren)
        {
            successesNeeded++;
        }
    }

    void Update()
    {
        if(tries == successesNeeded)
        {
            tries = 0;
            if(successes == successesNeeded && !puzzleCompleted)
            {                
                orderPuzzeManager.successesAchieved++;
                puzzleCompleted = true;
            }
            else
            {
                StartCoroutine(ResetSons());
            }
        }
    }

    public void CheckFirst()
    {
        if(!firstIsActive && !secondIsActive && !thirdIsActive && !fourthIsActive && !fithIsActive && !sixthIsActive && !seventhIsActive && !eightIsActive) 
        {
            firstIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckSecond()
    {
        if (firstIsActive && !secondIsActive && !thirdIsActive && !fourthIsActive && !fithIsActive && !sixthIsActive && !seventhIsActive && !eightIsActive)
        {
            secondIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckThird()
    {
        if (firstIsActive && secondIsActive && !thirdIsActive && !fourthIsActive && !fithIsActive && !sixthIsActive && !seventhIsActive && !eightIsActive)
        {
            thirdIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckFourth()
    {
        if (firstIsActive && secondIsActive && thirdIsActive && !fourthIsActive && !fithIsActive && !sixthIsActive && !seventhIsActive && !eightIsActive)
        {
            fourthIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckFith()
    {
        if (firstIsActive && secondIsActive && thirdIsActive && fourthIsActive && !fithIsActive && !sixthIsActive && !seventhIsActive && !eightIsActive)
        {
            fithIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckSixth()
    {
        if (firstIsActive && secondIsActive && thirdIsActive && fourthIsActive && fithIsActive && !sixthIsActive && !seventhIsActive && !eightIsActive)
        {
            sixthIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckSeventh()
    {
        if (firstIsActive && secondIsActive && thirdIsActive && fourthIsActive && fithIsActive && sixthIsActive && !seventhIsActive && !eightIsActive)
        {
            seventhIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    public void CheckEight()
    {
        if (firstIsActive && secondIsActive && thirdIsActive && fourthIsActive && fithIsActive && sixthIsActive && seventhIsActive && !eightIsActive)
        {
            eightIsActive = true;
            successes++;
            tries++;
        }
        else
        {
            tries++;
        }
    }

    IEnumerator ResetSons()
    {        
        //play sound of failed puzzle
        yield return new WaitForSeconds(1f);
        foreach (RPP_DeterminedOrderSon item in orderChildren)
        {
            item.ResetOrderChild();
        }
        firstIsActive = false;
        secondIsActive = false;
        thirdIsActive = false;
        fourthIsActive = false;
        fithIsActive = false;
        sixthIsActive = false;
        seventhIsActive = false;
        eightIsActive = false;
        successes = 0;
    }
}

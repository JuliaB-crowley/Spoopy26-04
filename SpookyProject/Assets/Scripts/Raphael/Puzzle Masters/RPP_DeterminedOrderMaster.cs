using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_DeterminedOrderMaster : MonoBehaviour
{
    [SerializeField] RPP_DeterminedOrderSon[] orderChildren;
    [SerializeField] RPP_SubPuzzleManager orderPuzzeManager;
    [SerializeField] bool firstIsActive, secondIsActive, thirdIsActive, fourthIsActive;
    bool puzzleCompleted = false;
    [SerializeField] int tries = 0, successes = 0, successesNeeded = 4;

    private void Start()
    {
        orderPuzzeManager = GetComponentInParent<RPP_SubPuzzleManager>();
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
        if(!firstIsActive && !secondIsActive && !thirdIsActive && !fourthIsActive)
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
        if (firstIsActive && !secondIsActive && !thirdIsActive && !fourthIsActive)
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
        if (firstIsActive && secondIsActive && !thirdIsActive && !fourthIsActive)
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
        if (firstIsActive && secondIsActive && thirdIsActive && !fourthIsActive)
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
        successes = 0;
    }
}

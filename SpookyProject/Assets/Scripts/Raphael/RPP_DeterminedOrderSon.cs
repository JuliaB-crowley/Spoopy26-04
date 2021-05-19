using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_DeterminedOrderSon : MonoBehaviour
{
    [SerializeField] bool isFirst, isSecond, isThird, isFourth, isButton, isTorch, hasBeenChecked = false;
    [SerializeField] RPP_BoutonScript buttonScript;
    [SerializeField] TestTorche torchScript;
    [SerializeField] RPP_DeterminedOrderMaster orderMaster;
    void Start()
    {
        orderMaster = GetComponentInParent<RPP_DeterminedOrderMaster>();
        if (isButton)
        {
            buttonScript = GetComponent<RPP_BoutonScript>();
        }
        if (isTorch)
        {
            torchScript = GetComponent<TestTorche>();
        }
    }

    void Update()
    {
        if (isButton)
        {
            if (buttonScript.hasBeenFlashed && !hasBeenChecked)
            {
                if (isFirst)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckFirst();
                }
                if (isSecond)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckSecond();
                }
                if (isThird)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckThird();
                }
                if (isFourth)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckFourth();
                }
            }
        }
        else if (isTorch)
        {
            if(torchScript.isLit && !hasBeenChecked)
            {
                if (isFirst)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckFirst();
                }
                if (isSecond)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckSecond();
                }
                if (isThird)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckThird();
                }
                if (isFourth)
                {
                    hasBeenChecked = true;
                    orderMaster.CheckFourth();
                }
            }
        }       
    }

    public void ResetOrderChild()
    {
        if (isButton)
        {
            hasBeenChecked = false;
            buttonScript.ResetButton();
        }
        else if (isTorch)
        {
            hasBeenChecked = false;
            torchScript.UnlitTorch();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_PlacementZoneScript : MonoBehaviour
{
    [SerializeField] RPP_SubPuzzleManager placementManager;
    [SerializeField] Transform[] successfulPositions;
    int currentPositionValue = 0;
    void Start()
    {
        placementManager = GetComponentInParent<RPP_SubPuzzleManager>();
    }

    private void Update()
    {
        if(placementManager.successesAchieved == placementManager.totalSuccessesRequired && placementManager.puzzleSolved)
        {
            FindObjectOfType<AudioManager>().Play("EnigmeVrai");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<JUB_PushableBehavior>() && !placementManager.puzzleSolved)
        {
            Debug.Log("A pushable object has been detected");
            //collision.gameObject.layer = 14; //The object must always be converted to the layer "Flashable Objects"
            collision.GetComponent<JUB_PushableBehavior>().pushed = false;
            collision.gameObject.transform.position = successfulPositions[currentPositionValue].position;
            collision.gameObject.transform.SetParent(successfulPositions[currentPositionValue]);            
            currentPositionValue ++;
            if (collision.CompareTag("Torche") && !collision.GetComponentInChildren<TestTorche>().hasBeenUsed)
            {
                collision.GetComponentInChildren<TestTorche>().hasBeenUsed = true;
                if (collision.GetComponentInChildren<TestTorche>().isLit)
                {
                    Debug.Log("The torch has been lit inside the zone");
                    placementManager.successesAchieved++;
                }
                else
                {
                    collision.GetComponentInChildren<TestTorche>().isPartOfAPuzzle = false;
                }
            }
            else
            {
                placementManager.successesAchieved++;
            }          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Torche") && collision.GetComponentInChildren<TestTorche>().hasBeenUsed)
        {
            collision.GetComponentInChildren<TestTorche>().hasBeenUsed = false;
            currentPositionValue--;

            if (collision.GetComponentInChildren<TestTorche>().isLit)
            {
                placementManager.successesAchieved--;
            }
        }
    }
}

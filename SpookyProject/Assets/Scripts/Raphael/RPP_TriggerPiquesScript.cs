using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

public class RPP_TriggerPiquesScript : MonoBehaviour
{
    [SerializeField] Material loopTrapMaterial;
    [SerializeField] JUB_Maeve hudManager;
    [SerializeField] float timeToPrepare = 0.6f, activeTrapTime = 0.2f, timeToReset = 0.5f;
    [SerializeField] int damage = 3;
    bool trapIsStandby = true, trapIsActive = false, canDamage = true;

    void Start()
    {
        loopTrapMaterial.color = Color.white;
        hudManager = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && trapIsStandby)
        {
            StartCoroutine(ActivateTrap());
        }
        else if (collision.CompareTag("Player") && trapIsActive && canDamage)
        {
            // Do Recoil
            hudManager.TakeDamages(damage);
            canDamage = false;
        }
    }

    IEnumerator ActivateTrap()
    {
        trapIsStandby = false;
        loopTrapMaterial.color = Color.yellow;
        yield return new WaitForSeconds(timeToPrepare);
        trapIsActive = true;
        loopTrapMaterial.color = Color.red;
        yield return new WaitForSeconds(activeTrapTime);
        loopTrapMaterial.color = Color.white;
        trapIsActive = false;
        canDamage = true;
        yield return new WaitForSeconds(timeToReset);
        trapIsStandby = true;
    }
}

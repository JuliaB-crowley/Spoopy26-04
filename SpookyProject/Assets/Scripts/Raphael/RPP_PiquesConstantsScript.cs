using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

public class RPP_PiquesConstantsScript : MonoBehaviour
{
    [SerializeField] JUB_Maeve hudManager;
    [SerializeField] float timeTilNextDmg = 1f;
    [SerializeField] int damage = 3;
    bool hasDoneDamage = false;

    private void Start()
    {
        hudManager = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasDoneDamage)
        {
            // Do Recoil
            StartCoroutine(DoDamage());
        }
    }

    IEnumerator DoDamage()
    {
        hasDoneDamage = true;
        hudManager.TakeDamages(damage);
        yield return new WaitForSeconds(timeTilNextDmg);
        hasDoneDamage = false;
    }
}

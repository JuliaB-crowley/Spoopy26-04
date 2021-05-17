using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

public class RPP_PiquesEnLoopScript : MonoBehaviour
{
    [SerializeField] Material loopTrapMaterial;
    [SerializeField] BoxCollider2D trapCollider;
    [SerializeField] JUB_Maeve hudManager;
    [SerializeField] float timeTilNextDmg = 1f, activeTrapTime = 0.2f;
    [SerializeField] int damage = 3;
    bool trapIsActive = false;

    private void Start()
    {
        trapCollider = this.GetComponent<BoxCollider2D>();
        trapCollider.enabled = false;
        loopTrapMaterial.color = Color.white;
        hudManager = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
    }

    private void Update()
    {
        if (!trapIsActive)
        {
            StartCoroutine(DoDamage());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Do Recoil
            hudManager.TakeDamages(damage);
        }
    }

    IEnumerator DoDamage()
    {
        trapIsActive = true;
        loopTrapMaterial.color = Color.red;
        trapCollider.enabled = true;
        yield return new WaitForSeconds(activeTrapTime);
        loopTrapMaterial.color = Color.white;
        trapCollider.enabled = false;
        yield return new WaitForSeconds(timeTilNextDmg);
        trapIsActive = false;
    }
}

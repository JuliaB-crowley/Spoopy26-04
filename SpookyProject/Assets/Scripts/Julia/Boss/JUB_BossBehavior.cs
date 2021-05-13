using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;

public class JUB_BossBehavior : MonoBehaviour
{
    public Animator SMBanimator;
    public int bossHitNumber = 0;
    public bool isInCombat;
    public bool canBeFlashed, isFlashed;
    public LayerMask playerLayer;
    public JUB_Maeve maeve;

    public float immunityTime;
    public bool isInImmunity;

    //attack paw
    public Collider2D pawCollider, pawAttackZone; //paw attack zone doit être sur l'objet qui contient ce script //paw collider sur un enfant
    public float flashRecoveryTime;
    public float buildupTime, recoveryTime, hitspanTime;
    public int pawDamages = 3;

    //attack spawn
    public GameObject spawningTrap;
    public int numberTrapPhase1, numberTrapPhase2, numberTrapPhase3;
    public Vector2 centerOfArea, sizeOfArea;
    public float timeBetweenTwo;

    //iddle elements
    public float timeBetweenAttacks;
    public Collider2D collierCollider; //un objet en enfant avec layer PointSensibleBoss 

    //flash elements
    public JUB_FlashManager flashManager, tailFlashManager; //pas sur le même objet évidemment
    public float timeBetweenTwoEyeBlinks;

    //burn tail elements
    public bool tailWasBurned;
    public float timeBurning;

    // Start is called before the first frame update
    void Start()
    {
        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();

        SMBanimator.GetBehaviour<BossSMB_Iddle>().boss = this;
        SMBanimator.GetBehaviour<BossSMB_PawAttack>().boss = this;
        SMBanimator.GetBehaviour<BossSMB_SpawnObject>().boss = this;

        canBeFlashed = true;

        centerOfArea = maeve.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossHitNumber == 1)
        {
            StartCoroutine(EyesClosingCoroutine()); //coroutine d'ouverture et de fermeture d'yeux
        }

        if(tailFlashManager.burned && bossHitNumber >= 2)
        {
            canBeFlashed = true;
            StartCoroutine(BurnTailRecovery()); //celui ci doit lancer le compteur de temps avant que la queue ne soit plus brulée
        }

        if(canBeFlashed && flashManager.flashed)
        {
            isFlashed = true; //empeche l'attaque de pattes
            StartCoroutine(FlashRecovery()); //recovery du flash
        }
    }

    public void TakeDamage()
    {
        if (!isInImmunity)
        {
            bossHitNumber++;
            isInImmunity = true;
            StartCoroutine(ImmunityAttacked());
            if (bossHitNumber == 2)
            {
                canBeFlashed = false;
            }
            if (bossHitNumber >= 3)
            {
                EndBattle();
            }

        }
    }
    

    void EndBattle()
    {
        isInCombat = false;
        //Time.timeScale = 0f;
        //lancer dialogue
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !isFlashed)
        {
            SMBanimator.Play("PawAttack");
        }
    }

    IEnumerator FlashRecovery()
    {
        yield return new WaitForSeconds(flashRecoveryTime);
        isFlashed = false;
    }

    IEnumerator BurnTailRecovery()
    {
        yield return new WaitForSeconds(timeBurning);
        canBeFlashed = false;
    }

    IEnumerator EyesClosingCoroutine()
    {
        yield return new WaitForSeconds(timeBetweenTwoEyeBlinks);
        canBeFlashed = !canBeFlashed;

        //faudra bien vérifier vis à vis de l'anim et régler à l'entrée de l'état
    }

    IEnumerator ImmunityAttacked()
    {
        yield return new WaitForSeconds(immunityTime);
        isInImmunity = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(centerOfArea, sizeOfArea);
    }
}

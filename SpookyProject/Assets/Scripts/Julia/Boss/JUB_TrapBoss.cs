using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_TrapBoss : JUB_DamagingEvent
{
    public float decayTime, activationTime;
    public Collider2D colliderTrap;

    //pour test
    public Animator graphAnim;

    // Start is called before the first frame update
    void Start()
    {
        graphAnim.Play("pics-enter");
        colliderTrap.enabled = false;
        StartCoroutine(ActivationCoroutine());
    }

    IEnumerator ActivationCoroutine()
    {
        yield return new WaitForSeconds(activationTime);
        graphAnim.Play("pics");
        FindObjectOfType<AudioManager>().Play("Pics");
        colliderTrap.enabled = true;
        Destroy(this.gameObject, decayTime);
    }

}

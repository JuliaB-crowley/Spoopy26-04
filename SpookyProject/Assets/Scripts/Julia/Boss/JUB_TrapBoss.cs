using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_TrapBoss : JUB_DamagingEvent
{
    public float decayTime, activationTime;
    public Collider2D colliderTrap;

    //pour test
    public Renderer trapRenderer;

    // Start is called before the first frame update
    void Start()
    {
        colliderTrap.enabled = false;
        StartCoroutine(ActivationCoroutine());
    }

    IEnumerator ActivationCoroutine()
    {
        yield return new WaitForSeconds(activationTime);
        trapRenderer.material.color = Color.Lerp(trapRenderer.material.color, Color.red, 0.8f);
        colliderTrap.enabled = true;
        Destroy(this.gameObject, decayTime);
    }

}

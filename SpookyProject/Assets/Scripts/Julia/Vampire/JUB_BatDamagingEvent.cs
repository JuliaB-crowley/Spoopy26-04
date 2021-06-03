using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_BatDamagingEvent : JUB_DamagingEvent
{
    // Start is called before the first frame update
    public GameObject parent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(parent);
        }
    }
}

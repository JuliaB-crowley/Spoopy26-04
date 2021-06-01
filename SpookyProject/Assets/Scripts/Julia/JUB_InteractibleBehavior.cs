using character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_InteractibleBehavior : MonoBehaviour
{
    public bool interactible, interacted, canBeShown = true;
    public GameObject player;
    public JUB_Maeve maeveScript;
    //[SerializeField] RPP_AfficheInteraction afficheInteraction;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        maeveScript = player.GetComponent<JUB_Maeve>();
        //afficheInteraction = GameObject.FindGameObjectWithTag("AfficheInteraction").GetComponent<RPP_AfficheInteraction>();
    }

    void Update()
    {
        if(interactible)
        {
            Vector2 thisToPlayer = transform.position - player.transform.position;
            float distanceToPlayer = thisToPlayer.magnitude;
            //afficheInteraction.shouldAppear = true;
            if (distanceToPlayer > maeveScript.interactAndPushableRange)
            {
                interactible = false;
            }
        }
        /*else
        {
            afficheInteraction.shouldAppear = false;
        }*/
    }
}

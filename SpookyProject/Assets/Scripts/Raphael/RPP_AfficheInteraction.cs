using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_AfficheInteraction : MonoBehaviour
{
    public SpriteRenderer affiche;
    public bool shouldAppear = false;
    public Sprite interactionButon, pushButon;
    void Start()
    {
        affiche = GetComponent<SpriteRenderer>();
        affiche.enabled = false;
    }

    void Update()
    {
        if (shouldAppear)
        {
            affiche.enabled = true;
        }
        else
        {
            affiche.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<JUB_InteractibleBehavior>() && collision.GetComponent<JUB_InteractibleBehavior>().canBeShown && !collision.GetComponent<JUB_InteractibleBehavior>().interacted)
        {
            affiche.sprite = interactionButon;
            shouldAppear = true;
        }
        else if (collision.GetComponent<JUB_PushableBehavior>())
        {
            affiche.sprite = pushButon;
            shouldAppear = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<JUB_InteractibleBehavior>() || collision.GetComponent<JUB_PushableBehavior>())
        {
            if (collision.GetComponent<JUB_InteractibleBehavior>() && (collision.GetComponent<JUB_InteractibleBehavior>().interacted))
            {
                shouldAppear = false;
            }
            shouldAppear = false;
        }
    }
}

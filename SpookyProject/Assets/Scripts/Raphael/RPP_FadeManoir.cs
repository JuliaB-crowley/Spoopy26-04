using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_FadeManoir : MonoBehaviour
{
    [SerializeField] SpriteRenderer manoirSprite;
    public bool playerIsBehind = false;
    public float alpha = 1f; //1 is opaque, 0 is transparent.
    void Start()
    {
        manoirSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(!playerIsBehind  && alpha <= 1)
        {
            Color currColor = manoirSprite.color;
            currColor.a = alpha;
            manoirSprite.color = currColor;
            alpha += 0.02f;
        }
        else if(playerIsBehind && alpha >= 0.3f)
        {
            Color currColor = manoirSprite.color;
            currColor.a = alpha;
            manoirSprite.color = currColor;
            alpha -= 0.02f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsBehind = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsBehind = false;
        }
    }
}

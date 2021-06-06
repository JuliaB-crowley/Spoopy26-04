using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_FadeManoir : MonoBehaviour
{
    [SerializeField] SpriteRenderer manoirSprite;
    public bool playerIsBehind = false;
    public Color tmp;
    void Start()
    {
        manoirSprite = GetComponent<SpriteRenderer>();
        tmp = manoirSprite.color;
        manoirSprite.color = tmp;
    }

    void Update()
    {
        if(!playerIsBehind && tmp.a <=255)
        {
            Debug.Log("The house is reappearing");
            tmp.a = 255;
        }
        else if(playerIsBehind && tmp.a >= 40)
        {
            Debug.Log("The house is fading");
            tmp.a = 40;
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

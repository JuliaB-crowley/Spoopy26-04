using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPP_SceneTransition : MonoBehaviour
{
    public bool isInNeborhood, isInDungeon;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isInNeborhood)
        {
            SceneManager.LoadScene("Prototype_Dungeon");
        }
        else if(collision.CompareTag("Player") && isInDungeon)
        {
            SceneManager.LoadScene("BossRoom");
        }
    }
}

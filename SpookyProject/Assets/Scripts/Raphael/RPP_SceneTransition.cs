using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RPP_SceneTransition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && SceneManager.sceneCount==1)
        {
            SceneManager.LoadScene("Prototype_Dungeon");
        }
        else if(SceneManager.sceneCount == 2)
        {
            SceneManager.LoadScene("BossRoom");
        }
    }
}

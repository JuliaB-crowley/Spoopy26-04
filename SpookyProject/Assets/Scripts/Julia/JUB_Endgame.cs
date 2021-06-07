using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JUB_Endgame : MonoBehaviour
{
    public JUB_BossBehavior boss;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && boss.isDead)
        {
            SceneManager.LoadScene("Outro");
        }
    }


}

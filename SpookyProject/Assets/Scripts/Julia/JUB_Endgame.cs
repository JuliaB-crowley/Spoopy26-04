using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JUB_Endgame : MonoBehaviour
{
    public GameObject victoryCanvas;
    // Start is called before the first frame update
    void Start()
    {
        victoryCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Outro");
        }
    }


}

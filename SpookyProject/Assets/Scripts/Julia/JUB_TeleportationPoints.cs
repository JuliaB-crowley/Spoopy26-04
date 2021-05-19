using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_TeleportationPoints : MonoBehaviour
{
    public Transform pointA, pointB;
    public GameObject player;
    public float cooldown = 1;
    public bool pointADesactivated, pointBDesactivated;
    public JUB_Fondu fonduScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fonduScript = FindObjectOfType<JUB_Fondu>().GetComponent<JUB_Fondu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.transform.position, pointA.position) < 1 && !pointADesactivated)
        {

            fonduScript.FadeIn();
            StartCoroutine(Teleport());
            StartCoroutine(Reactivate());
        }
        /*else if(Vector2.Distance(player.transform.position, pointB.position) < 1 && !pointBDesactivated)
        {
            player.transform.position = pointA.transform.position;
            pointADesactivated = true;
            StartCoroutine(Reactivate());
        }*/
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.2f);
        player.transform.position = pointB.transform.position;
        pointBDesactivated = true;
    }
    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(cooldown);
        pointBDesactivated = false;
        pointADesactivated = false;
    }
}

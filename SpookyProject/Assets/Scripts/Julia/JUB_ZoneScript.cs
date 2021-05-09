using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUB_ZoneScript : MonoBehaviour
{
    [SerializeField]
    bool isInterior, playerIsHere;
    public GameObject player;
    public Vector3 offSet;
    public Transform cameraTransform, playerTransform, roomCameraPoint;
    public float cameraSpeed, smoothSpeed = 0.125f;

    //système d'indices 
    Controller controller;
    [SerializeField]
    string[] indice;
    public GameObject canvasIndice;
    public Text indiceText;
    int readHint;
    bool hintOpen;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        controller.Enable();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        //glisser déposer le roomCameraPoint si isInterior

        canvasIndice.GetComponent<Transform>().localScale = Vector3.zero;

        controller.MainController.Hint.performed += ctx => Hint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isInterior == false && playerIsHere == true)
        {
            Vector3 desiredPosition = playerTransform.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed);
            cameraTransform.position = smoothedPosition;
            cameraTransform.LookAt(playerTransform);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("is in zone !" + isInterior.ToString());

            playerIsHere = true;
            if(isInterior == true)
            {
                cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, roomCameraPoint.position, cameraSpeed * Time.deltaTime);
            }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
            playerIsHere = false;
    }

    private void Hint()
    {
        if(playerIsHere && !hintOpen)
        {
            canvasIndice.GetComponent<Transform>().localScale = Vector3.one;
            Time.timeScale = 0f;
            hintOpen = true;

            if (readHint == 0)
            {
                indiceText.GetComponent<CoolTextScript>().Read(indice[0]);
                readHint++;

            }
            else if(readHint == 1)
            {
                indiceText.GetComponent<CoolTextScript>().Read(indice[1]);
                readHint++;
            }
            else if (readHint >= 2)
            {
                indiceText.GetComponent<CoolTextScript>().Read(indice[2]);
            }
        }
        else if (hintOpen)
        {
            canvasIndice.GetComponent<Transform>().localScale = Vector3.zero;
            Time.timeScale = 1f;
            hintOpen = false;
        }
    }
}

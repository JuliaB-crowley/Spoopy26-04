using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using character;

public class JUB_ZoneScript : MonoBehaviour
{
    [SerializeField]
    bool isInterior, playerIsHere;
    public Vector3 offSet;
    public Transform cameraTransform, playerTransform, roomCameraPoint;
    public float cameraSpeed, smoothSpeed = 0.125f, modifiedCameraSize = 1;
    float baseCameraSize;
    public Transform checkpoint;
    public JUB_Maeve player;
    
    //système d'indices 
    Controller controller;
    [SerializeField]
    string[] indice;
    public GameObject canvasIndice;
    public Camera mainCam;
    public Text indiceText;
    public int readHint;
    public bool hintOpen;
    public float refSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canvasIndice = GameObject.FindGameObjectWithTag("Hint Canvas");
        indiceText = GameObject.FindGameObjectWithTag("Hint Canvas").GetComponentInChildren<Text>();
        controller = new Controller();
        controller.Enable();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        cameraTransform = mainCam.transform;
        //glisser déposer le roomCameraPoint si isInterior
        

        canvasIndice.GetComponent<Transform>().localScale = Vector3.zero;

        controller.MainController.Hint.performed += ctx => Hint();

        baseCameraSize = mainCam.orthographicSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isInterior == false && playerIsHere == true)
        {
            Vector3 desiredPosition = playerTransform.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(cameraTransform.position, desiredPosition, smoothSpeed);
            cameraTransform.position = smoothedPosition;
            //cameraTransform.LookAt(playerTransform);
        }

        if (isInterior == true && playerIsHere)
        {
            //Debug.Log("oui je vais là");
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, roomCameraPoint.position, cameraSpeed);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("is in zone !" + isInterior.ToString());

        playerIsHere = true;
        player.actualCheckpoint = checkpoint;
        if (isInterior == true && playerIsHere)
        {
            StartCoroutine(ZoomCoroutine(baseCameraSize * roomCameraPoint.localScale.z));
        }
        else
        {
            StartCoroutine(ZoomCoroutine(baseCameraSize * modifiedCameraSize));
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerIsHere = false;
        //StartCoroutine(ZoomCoroutine(baseCameraSize));
    }

    private void Hint()
    {
        if (playerIsHere && !hintOpen)
        {
            canvasIndice.GetComponent<Transform>().localScale = Vector3.one;
            Time.timeScale = 0f;
            hintOpen = true;

            if (readHint == 0)
            {
                indiceText.GetComponent<CoolTextScript>().Read(indice[0]);
                readHint++;

            }
            else if (readHint == 1)
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

    IEnumerator ZoomCoroutine(float target)
    {

        while (mainCam.orthographicSize != target)
        {
            //Debug.Log("zoom coroutine");
            if (mainCam.orthographicSize < target)
            {
                mainCam.orthographicSize += refSpeed * Time.deltaTime;
                if(mainCam.orthographicSize > target)
                {
                    mainCam.orthographicSize = target;
                }
            }
            else
            {
                mainCam.orthographicSize -= refSpeed * Time.deltaTime;
                if(mainCam.orthographicSize < target)
                {
                    mainCam.orthographicSize = target;
                }
            }
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuTest : MonoBehaviour
{

    public GameObject rescaleCanvas, optionRescaleCanvas;
    public Controller controller;

    public GameObject firstButtonSelected, optionsFirstButton, optionsCloseButton;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        controller.Enable();
        rescaleCanvas.GetComponent<Transform>().localScale = Vector3.zero;

        optionRescaleCanvas.GetComponent<Transform>().localScale = Vector3.zero;

        controller.MainController.Pause.performed += ctx => OpenMenu();
    }

    public void ClosePauseMenu()
    {
        rescaleCanvas.GetComponent<Transform>().localScale = Vector3.zero;
        Time.timeScale = 1f;

        optionRescaleCanvas.GetComponent<Transform>().localScale = Vector3.zero;
    }

    public void ToOptionsMenu()
    {
        Debug.Log("aled");
        rescaleCanvas.GetComponent<Transform>().localScale = Vector3.zero;
        optionRescaleCanvas.GetComponent<Transform>().localScale = Vector3.one;
        optionRescaleCanvas.SetActive(true);
        //CLEAR SELECTED OBJECT
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void Back()
    {
        rescaleCanvas.GetComponent<Transform>().localScale = Vector3.one;
        optionRescaleCanvas.GetComponent<Transform>().localScale = Vector3.zero;
        //CLEAR SELECTED OBJECT
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(optionsCloseButton);
    }

    public void OpenMenu()
    {
        rescaleCanvas.GetComponent<Transform>().localScale = Vector3.one;
        Time.timeScale = 0f;

        //CLEAR SELECTED OBJECT
        EventSystem.current.SetSelectedGameObject(null);
        //set a new selected object
        EventSystem.current.SetSelectedGameObject(firstButtonSelected);
    }
}

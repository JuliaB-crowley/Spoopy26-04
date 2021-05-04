using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseUI : MonoBehaviour
{
    public LayerMask UI;
    public Controller controller;
    public Camera mainCamera;
    public List<Collider2D> btns;

    // Start is called before the first frame update
    void Start()
    {
        controller = new Controller();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Mouse mouse = Mouse.current;
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(mouse.position.ReadValue());


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, UI))
        {
            hit.collider.GetComponent<JUB_BehaviorButton>().Hover();
            hit.collider.GetComponent<JUB_BehaviorButton>().mouseOnButton = true;
        }

        foreach (Collider2D button in btns)
        {
            if (button.GetComponent<Collider>() != hit.collider)
            {
                button.GetComponent<JUB_BehaviorButton>().NotHover();
            }
        }


    }

}

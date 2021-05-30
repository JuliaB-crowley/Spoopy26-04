using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUB_Notebook : MonoBehaviour
{
    public GameObject canvasLivre;
    public Text canvasText;
    [TextArea (5, 20)]
    public string contenuJournal;
    public JUB_InteractibleBehavior interactible;

    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        canvasLivre = GameObject.FindGameObjectWithTag("NotebookCanvas");
        canvasText = canvasLivre.GetComponentInChildren<Text>();
        interactible = GetComponentInChildren<JUB_InteractibleBehavior>();
        canvasLivre.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interactible.interacted == true && !isOpen)
        {
            isOpen = true;
            canvasText.text = contenuJournal;
            Time.timeScale = 0f;
            interactible.interacted = false;
            canvasLivre.SetActive(true);
        }

        if(interactible.interacted == true && isOpen)
        {
            isOpen = false;
            Time.timeScale = 1f;
            interactible.interacted = false;
            canvasLivre.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;
using UnityEngine.UI;

public class JUB_DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Sprite> imageNPC;

    public Text text;
    public Image faceImage;
    public Transform resizeCanvas;
    public float timeBetweenLetters;

    JUB_Maeve maeve;
    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        imageNPC = new Queue<Sprite>();

        controller = new Controller();
        controller.Enable();

        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        resizeCanvas.localScale = Vector3.zero;

        controller.MainController.Roll.performed += ctx => DisplayNextSentence();
        
    }

    public void StartDialogue(JUB_Dialogue dialogue)
    {
        maeve.isInDialogue = true;
        resizeCanvas.localScale = Vector3.one;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite sprite in dialogue.npcFaces)
        {
            imageNPC.Enqueue(sprite);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        Sprite sprite = imageNPC.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        faceImage.sprite = sprite;
        Debug.LogWarning(sentence);
    }

    IEnumerator TypeSentence(string sentence)
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }

    void EndDialogue()
    {
        resizeCanvas.localScale = Vector3.zero;
    }
}

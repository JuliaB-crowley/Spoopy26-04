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
    public bool isReading;
    public string actualPhrase;

    JUB_Maeve maeve;
    public Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        imageNPC = new Queue<Sprite>();

        controller = new Controller();
        controller.Enable();

        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        resizeCanvas.localScale = Vector3.zero;

        controller.Menu.Dialogues.performed += ctx => DisplayNextSentence();
        
    }

    public void StartDialogue(JUB_Dialogue dialogue)
    {
        Time.timeScale = 0f;
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
        Debug.LogWarning(sentences);
        maeve.isInDialogue = false;
        if(sentences.Count == 0 && isReading == false)
        {
            EndDialogue();
            return;
        }


        maeve.isInDialogue = true;
        StopAllCoroutines();

        if (isReading)
        {
            StopAllCoroutines();
            text.text = actualPhrase;
            isReading = false;
        }
        else
        {
            string sentence = sentences.Dequeue();
            Sprite sprite = imageNPC.Dequeue();
            isReading = true;
            StartCoroutine(TypeSentence(sentence));
            actualPhrase = sentence;
            faceImage.sprite = sprite;
            Debug.LogWarning(sentence);
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        text.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return StartCoroutine(JUB_RealtimeCoroutine.WaitForRealSeconds(timeBetweenLetters));
        }
        isReading = false;
    }

    void EndDialogue()
    {
        Debug.LogWarning("je passe par là");
        Time.timeScale = 1f;
        resizeCanvas.localScale = Vector3.zero;
    }
}

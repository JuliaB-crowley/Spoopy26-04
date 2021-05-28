using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using character;
using UnityEngine.UI;

public class JUB_BossStartScript : MonoBehaviour
{
    private Queue<string> sentences;
    private Queue<Sprite> imageNPC;

    public Text text;
    public Image faceImage;
    public Transform resizeCanvas;
    public float timeBetweenLetters;

    JUB_Maeve maeve;
    Controller controller;
    public JUB_Dialogue introBossDialogue;

    public bool dialogueWasSaid;
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
        if (sentences.Count == 0)
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
            yield return StartCoroutine(JUB_RealtimeCoroutine.WaitForRealSeconds(timeBetweenLetters));
        }
    }

    void EndDialogue()
    {
        Time.timeScale = 1f;
        maeve.isInDialogue = false;
        resizeCanvas.localScale = Vector3.zero;
        FindObjectOfType<JUB_BossBehavior>().StartFight();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!dialogueWasSaid)
        {
            StartDialogue(introBossDialogue);
            dialogueWasSaid = true;
        }
    }
}

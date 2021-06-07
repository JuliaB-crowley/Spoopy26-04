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
    JUB_QuestManager questManager;
    bool isReading;
    string actualPhrase;
    public JUB_DialogueManager dialogueManager;

    public bool dialogueWasSaid;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        imageNPC = new Queue<Sprite>();

        controller = new Controller();
        controller.Enable();

        maeve = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Maeve>();
        questManager = GameObject.FindGameObjectWithTag("HUD").GetComponent<JUB_QuestManager>();
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<JUB_DialogueManager>();
        dialogueManager.controller.Disable();
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
            StartCoroutine(TypeSentence(sentence));
            isReading = true;
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
        Debug.Log("présent");
        questManager.UpdateObjective(10);
        Time.timeScale = 1f;
        maeve.isInDialogue = false;
        resizeCanvas.localScale = Vector3.zero;
        FindObjectOfType<JUB_BossBehavior>().StartFight();
        dialogueManager.controller.Enable();
        Destroy(this);
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

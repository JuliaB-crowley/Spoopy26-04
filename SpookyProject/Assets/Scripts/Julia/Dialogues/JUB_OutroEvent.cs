using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JUB_OutroEvent : MonoBehaviour
{
    private Queue<string> sentences;
    public JUB_Dialogue outroDialogue;
    private Queue<Sprite> imageNPC;

    public Text text;
    public Image npcFace;
    public float timeBetweenLetters;

    bool isReading;
    string actualPhrase;

    public GameObject victoryCanvas, canvasDialogueDeSesMorts;

    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        imageNPC = new Queue<Sprite>();

        controller = new Controller();
        controller.Enable();

        victoryCanvas.SetActive(false);

        StartDialogue(outroDialogue);

        controller.Menu.Dialogues.performed += ctx => DisplayNextSentence();
    }

    public void StartDialogue(JUB_Dialogue dialogue)
    {
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
            npcFace.sprite = sprite;
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
        StopAllCoroutines();
        victoryCanvas.SetActive(true);
        canvasDialogueDeSesMorts.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

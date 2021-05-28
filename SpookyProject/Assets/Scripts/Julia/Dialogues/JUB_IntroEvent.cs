using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JUB_IntroEvent : MonoBehaviour
{
    private Queue<string> sentences;
    public JUB_Dialogue introDialogue;

    public Text text;
    public float timeBetweenLetters;

    public string nomSceneSuivante;

    Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        controller = new Controller();
        controller.Enable();

        StartDialogue(introDialogue);

        controller.Menu.Dialogues.performed += ctx => DisplayNextSentence();
    }

    public void StartDialogue(JUB_Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        StartCoroutine(TypeSentence(sentence));
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
            SceneManager.LoadScene(nomSceneSuivante);
        
    }
}

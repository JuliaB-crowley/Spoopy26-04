using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_SpeakingEvent : MonoBehaviour
{
    public JUB_Dialogue dialogue;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<JUB_DialogueManager>().StartDialogue(dialogue);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_DialogueTrigger : MonoBehaviour
{
    public JUB_Dialogue dialogue;
    public JUB_InteractibleBehavior interactibleBehavior;
    // Start is called before the first frame update
    void Start()
    {
        interactibleBehavior = GetComponentInChildren<JUB_InteractibleBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactibleBehavior.interacted == true)
        {
            TriggerDialogue();
            interactibleBehavior.interacted = false;
        }
    }

    public void TriggerDialogue()
    {
        GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<JUB_DialogueManager>().StartDialogue(dialogue);
    }
}

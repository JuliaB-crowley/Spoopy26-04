using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_MamieEvent : MonoBehaviour
{
    bool hasTalkedToMamie, dialogueWasSaid;
    public JUB_InteractibleBehavior interactibleBehavior;
    public JUB_Dialogue postMamieDialogue;
    JUB_DialogueManager dialogueManager;
    public Collider2D talkingCollider;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<JUB_DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(interactibleBehavior.interacted == true)
        {
            hasTalkedToMamie = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !dialogueWasSaid && hasTalkedToMamie)
        {
            dialogueWasSaid = true;
            dialogueManager.StartDialogue(postMamieDialogue);
        }
    }
}

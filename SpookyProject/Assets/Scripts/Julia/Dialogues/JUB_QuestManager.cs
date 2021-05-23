using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUB_QuestManager : MonoBehaviour
{
    //public JUB_Dialogue nomDialogue; //A RAJOUTER AU FUR ET A MESURE QU'ON VEUT DES DIALOGUES
    public string[] objectivesName;
    public Text questBookText;
    public JUB_DialogueManager dialogueManager;
    public bool firstKeyPartObtained = false;
    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = GameObject.FindGameObjectWithTag("DialogueManager").GetComponent<JUB_DialogueManager>();
        questBookText.text = objectivesName[0];
    }

    public void UpdateObjective(int ItemID)
    {
        questBookText.text = objectivesName[ItemID];
        //si y a un dialogue associé faire un if (itemID = numéro voulu) puis mettre cette ligne dedans
        //dialogueManager.StartDialogue(nom dialogue correspondant);

        if(!firstKeyPartObtained && ItemID == 4)
        {
            firstKeyPartObtained = true;

        }
        if(firstKeyPartObtained && ItemID == 4)
        {
            questBookText.text = objectivesName[5];
        }
    }
}

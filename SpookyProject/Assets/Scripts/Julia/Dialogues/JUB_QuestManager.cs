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
    public JUB_Dialogue Intro;
    public JUB_Dialogue MamieCitrouille;
    public JUB_Dialogue MaisonPortail;
    public JUB_Dialogue FirstKey;
    public JUB_Dialogue SecondKey;
    public JUB_Dialogue QuartierEst;
    public JUB_Dialogue RentrerChezMoi;
    public JUB_Dialogue Gardien;
    bool introSaid, mamieSaid, portailSaid, firstSaid, secondKeySaid, quartierEstSaid, rentrerSaid, gardienSaid;
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

        if(!firstKeyPartObtained && ItemID == 4 && !firstSaid)
        {
            firstSaid = true;
            firstKeyPartObtained = true;
            dialogueManager.StartDialogue(FirstKey);

        }
        if(firstKeyPartObtained && ItemID == 4 && !secondKeySaid)
        {
            secondKeySaid = true;
            questBookText.text = objectivesName[5];
            dialogueManager.StartDialogue(SecondKey);
        }
        if(ItemID == 1 && !introSaid)
        {
            introSaid = true;
            dialogueManager.StartDialogue(Intro);
        }
        if (ItemID == 2 && !mamieSaid)
        {
            mamieSaid = true;
            dialogueManager.StartDialogue(MamieCitrouille);
        }
        if(ItemID == 3 && !portailSaid)
        {
            portailSaid = true;
            dialogueManager.StartDialogue(MaisonPortail);
        }
        if(ItemID == 6 && !quartierEstSaid)
        {
            quartierEstSaid = true;
            dialogueManager.StartDialogue(QuartierEst);
        }
        if(ItemID == 7 && !rentrerSaid)
        {
            rentrerSaid = true;
            dialogueManager.StartDialogue(RentrerChezMoi);
        }
        if(ItemID == 8 && !gardienSaid)
        {
            gardienSaid = true;
            dialogueManager.StartDialogue(Gardien);
        }
    }
}

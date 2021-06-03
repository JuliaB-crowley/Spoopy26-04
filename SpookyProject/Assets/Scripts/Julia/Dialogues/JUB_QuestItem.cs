using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_QuestItem : MonoBehaviour
{
    [SerializeField]
    int itemID;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("HUD").GetComponent<JUB_QuestManager>().UpdateObjective(itemID);
            Destroy(this.gameObject);
        }
    }
}

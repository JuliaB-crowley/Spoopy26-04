using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_BossZone : MonoBehaviour
{
    [SerializeField]
    int itemID;

    public JUB_BossBehavior boss;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && boss.isDead == true)
        {
            GameObject.FindGameObjectWithTag("HUD").GetComponent<JUB_QuestManager>().UpdateObjective(itemID);
            Destroy(this.gameObject);
        }
    }
}

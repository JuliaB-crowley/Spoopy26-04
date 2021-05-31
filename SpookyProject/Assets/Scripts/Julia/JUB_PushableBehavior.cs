using character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_PushableBehavior : MonoBehaviour
{
    [SerializeField] //BoxCollider2D objectCollider;
    public bool pushable, pushed;
    public Transform playerTransform;
    public GameObject pushableObject;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pushableObject = this.gameObject;
    }

    // Update is called once per frame

    public void ManagePushing()
    {
        if (pushed == true)
        {
            pushableObject.transform.SetParent(playerTransform);
            //objectCollider.enabled = false;
        }

        if (pushed == false)
        {
            pushableObject.transform.SetParent(null);
            //objectCollider.enabled = true;
        }
    }
}

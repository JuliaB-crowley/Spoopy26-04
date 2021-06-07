using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_BreakableBehavior : MonoBehaviour
{
    [SerializeField] RPP_InvisibleInkScript invisibleScript;
    public List<GameObject> possibleLoots;
    public float breakTime;
    [SerializeField] bool needsInvisibleScript = false;

    private void Start()
    {
        if (needsInvisibleScript)
        {
            invisibleScript = GetComponent<RPP_InvisibleInkScript>();
        }
    }

    public void Breaking()
    {
        if (!needsInvisibleScript)
        {
            if (possibleLoots.Count > 0)
            {
                Debug.Log("a vase has been destroyed");
                GetComponentInChildren<SpriteRenderer>().enabled = false;
                int index = Random.Range(0, possibleLoots.Count - 1);
                Instantiate(possibleLoots[index], transform.position, Quaternion.identity);
            }
            StartCoroutine(DestroyCoroutine());
        }
        else
        {
            if (possibleLoots.Count > 0 && invisibleScript.isVisible)
            {
                Debug.Log("an invisible vase has been destroyed");
                GetComponent<SpriteRenderer>().enabled = false;
                int index = Random.Range(0, possibleLoots.Count - 1);
                Instantiate(possibleLoots[index], transform.position, Quaternion.identity);
                StartCoroutine(DestroyCoroutine());
            }       
        }       
    }

    IEnumerator DestroyCoroutine()
    {
        FindObjectOfType<AudioManager>().Play("PumpkinDestroyed");
        yield return new WaitForSeconds(breakTime);
        Destroy(gameObject);
    }
}

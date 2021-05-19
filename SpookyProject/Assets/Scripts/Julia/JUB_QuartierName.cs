using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUB_QuartierName : MonoBehaviour
{
    public Text nameText;
    public string nameQuartier;
    public Animator bandeauAnimator;
    public GameObject bandeauCapricieux;
    public float timeVisible = 2f;

    // Start is called before the first frame update
    private void Start()
    {
        bandeauCapricieux.transform.localScale = Vector3.zero;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            nameText.text = nameQuartier;
            bandeauAnimator.Play("Ouverture bandeau");
            StartCoroutine(WaintingCoroutine());
        }
    }

    IEnumerator WaintingCoroutine()
    {
        yield return new WaitForSeconds(timeVisible);
        bandeauAnimator.Play("Fermeture bandeau");
    }
}

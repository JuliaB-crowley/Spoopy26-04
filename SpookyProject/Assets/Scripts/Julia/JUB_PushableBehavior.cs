using character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_PushableBehavior : MonoBehaviour
{
    [SerializeField] BoxCollider2D objectCollider;
    public bool pushable, pushed, playedPushObject = false;
    public Transform playerTransform;
    public GameObject pushableObject;
    public ParticleSystem pushingParticles;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        pushableObject = this.gameObject;

        pushingParticles.Stop();
    }

    // Update is called once per frame
    private void Update()
    {
        if (pushed && !playedPushObject)
        {
            StartCoroutine(PushSound());
        }
    }

    public void ManagePushing()
    {
        if (pushed == true)
        {
            pushableObject.transform.SetParent(playerTransform);
            pushingParticles.Play();
            objectCollider.enabled = false;
        }

        if (pushed == false)
        {
            pushableObject.transform.SetParent(null);
            pushingParticles.Pause();
            pushingParticles.Clear();
            objectCollider.enabled = true;
        }
    }

    IEnumerator PushSound()
    {
        playedPushObject = true;
        FindObjectOfType<AudioManager>().Play("PushObject");
        yield return new WaitForSeconds(1.2f);
        playedPushObject = false;
    }
}

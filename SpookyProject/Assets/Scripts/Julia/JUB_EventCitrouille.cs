using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_EventCitrouille : MonoBehaviour
{
    public JUB_InteractibleBehavior interactible;
    public JUB_Flash flash;
    // Start is called before the first frame update
    void Start()
    {
        flash = GameObject.FindGameObjectWithTag("Player").GetComponent<JUB_Flash>();
        interactible = GetComponentInChildren<JUB_InteractibleBehavior>();
        flash.flashWasObtained = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(interactible.interacted)
        {
            flash.flashWasObtained = true;
            interactible.interacted = false;
            Destroy(this.gameObject);
        }
    }
}

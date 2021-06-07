using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_TPentrance : MonoBehaviour
{
    public Vector3 positionMaeve;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = positionMaeve;
    }

}

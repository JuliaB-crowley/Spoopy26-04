using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPP_CollectibleScript : MonoBehaviour
{
    public GameObject collectibleObject;
    public int collectibleValeur;

    private void Awake()
    {
        collectibleObject = this.gameObject;
    }
}

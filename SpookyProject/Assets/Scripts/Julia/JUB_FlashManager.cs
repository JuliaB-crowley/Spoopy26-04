using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUB_FlashManager : MonoBehaviour
{
    public bool burned, flashed;
    public float flashTime = 1;

    public void FlashEnd(float timeFlashing)
    {
        StartCoroutine(FlashEndCoroutine(timeFlashing));
    }
    public IEnumerator FlashEndCoroutine(float timeFlashing)
    {
        yield return new WaitForSeconds(timeFlashing);
        flashed = false;
        Debug.Log("flash désactivé");
    }
    public void BurnEnd(float timeBurning)
    {
        StartCoroutine(BurnEndCoroutine(timeBurning));
    }
    public IEnumerator BurnEndCoroutine(float timeBurning)
    {
        yield return new WaitForSeconds(timeBurning);
        burned = false;
    }
}

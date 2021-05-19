using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUB_Fondu : MonoBehaviour
{
    [SerializeField]
    Image fadeImage;
    [SerializeField]
    float timeFading, timeBlack;

    private void Start()
    {
        fadeImage.CrossFadeAlpha(0, 0f, false);
    }
    public void FadeIn()
    {
        fadeImage.CrossFadeAlpha(1, timeFading, false);
        StartCoroutine(FadeOut());
        
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeBlack);
        fadeImage.CrossFadeAlpha(0, timeFading, false);
    }
}

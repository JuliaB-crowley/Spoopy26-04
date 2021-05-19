using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrossirBouton : MonoBehaviour
{
    public RectTransform size;
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        size = GetComponent<RectTransform>();
        scale = size.localScale;
    }
    public void Hover()
    {
        size.localScale = scale * 1.1f;
    }

    public void NotHover()
    {
        size.localScale = scale;
    }
}

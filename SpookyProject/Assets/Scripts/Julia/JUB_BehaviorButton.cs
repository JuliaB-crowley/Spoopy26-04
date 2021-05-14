using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JUB_BehaviorButton : MonoBehaviour
{
    public Button btn;
    public RectTransform size;
    public Vector3 scale;
    public bool mouseOnButton;
    public int buttonNumber;
    public Text descriptionText, nameText;
    public GameObject resizeDescriptionCanvas;
    public JUB_Boutique scriptBoutique;

    // Start is called before the first frame update
    void Start()
    {
        resizeDescriptionCanvas.transform.localScale = Vector3.zero;
        btn = GetComponent<Button>();
        size = GetComponent<RectTransform>();
        scale = size.localScale;
    }

    public void Hover()
    {
        descriptionText.text = scriptBoutique.items[buttonNumber].scriptableObject.itemDescription;
        nameText.text = scriptBoutique.items[buttonNumber].scriptableObject.itemName;
        resizeDescriptionCanvas.transform.localScale = Vector3.one;
        size.localScale = scale * 1.1f;
    }

    public void NotHover()
    {
        resizeDescriptionCanvas.transform.localScale = Vector3.zero;
        size.localScale = scale;
    }
}

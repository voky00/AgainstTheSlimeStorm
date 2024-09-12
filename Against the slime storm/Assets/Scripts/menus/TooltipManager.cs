using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager instance;

    public TextMeshProUGUI textComponent;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }else
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ofset the tooltip next to the mouse
        Vector3 offset = new Vector3(125, 40, 0);
        transform.position = Input.mousePosition + offset;
        //set widht and height of this to fit the text
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(textComponent.preferredWidth + 20, textComponent.preferredHeight + 20);
        

    }

    public void ShowTooltip(string text)
    {
        gameObject.SetActive(true);
        textComponent.text = text;
        transform.SetAsLastSibling();
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        textComponent.text = "";
    }
}

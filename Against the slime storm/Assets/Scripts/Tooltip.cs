using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    //enable \n in the inspector
    [Multiline] public string message;
    bool pointerExited=true;

    //OnMouseEnter and on mouse exit for gameobjects
    private void OnMouseEnter()
    {
        pointerExited = false;

        if (Time.timeScale == 0)
            ShowTooltip();

        if (message != null)
        {
            //TooltipManager.instance.ShowTooltip(message);
            Invoke("ShowTooltip", 0.5f);

        }
    }

    private void OnMouseExit()
    {
        pointerExited = true;
        TooltipManager.instance.HideTooltip();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //after few seconds show the tooltip
        //ShowTooltip();
        pointerExited = false;
        
        if(Time.timeScale == 0)        
            ShowTooltip();
        
        if (message != null)
        {
            //TooltipManager.instance.ShowTooltip(message);
            Invoke("ShowTooltip", 0.5f);
            
        } 
    }

    private void ShowTooltip()
    {
        if (pointerExited)
            return;
        TooltipManager.instance.ShowTooltip(message);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        pointerExited = true;
        TooltipManager.instance.HideTooltip();
    }
}

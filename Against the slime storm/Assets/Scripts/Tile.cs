using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    public Tower tower;
    //Color startcolor;

    private void OnMouseEnter()
    {
        if(tower == null)
            GetComponent<Renderer>().enabled = true;
            //startcolor = GetComponent<Renderer>().material.color;
            //GetComponent<Renderer>().material.color = startcolor + new Color(0, 0, 0, 0.5f);
    }

    private void OnMouseExit()
    {
        if (tower == null)
            GetComponent<Renderer>().enabled = false;
        //GetComponent<Renderer>().material.color = startcolor;
    }

    private void OnMouseDown()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && tower == null)
        {
            GameManager.Instance.selectedTile = gameObject;
            GameManager.Instance.TowerMenu.transform.position = Input.mousePosition + new Vector3(120, 120, 0);
            GameManager.Instance.TowerMenu.SetActive(true);
            
        }

    }

}

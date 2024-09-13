using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerBuild : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    
    public Tower Tower;
    Color startcolor;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameManager.Instance.Money >= Tower.goldCost && GameManager.Instance.Lumber >= Tower.woodCost)
        {
            //instantiate tower 90 degrees rotated
            Tower tower = Instantiate(Tower, GameManager.Instance.selectedTile.transform.position + new Vector3(0,5,0), Quaternion.Euler(0, 90, 0));
            tower.transform.SetParent(GameManager.Instance.selectedTile.transform);
            GameManager.Instance.Money -= Tower.goldCost;
            GameManager.Instance.Lumber -= Tower.woodCost;
            //GameManager.Instance.selectedTile.SetActive(false);
            GameManager.Instance.selectedTile.GetComponent<Tile>().tower = tower;
            GameManager.Instance.TowerMenu.SetActive(false);
            transform.GetComponent<Tooltip>().OnPointerExit(eventData);

        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        startcolor = GetComponent<Image>().color;
        GetComponent<Image>().color = Color.blue;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = startcolor;
    }
}

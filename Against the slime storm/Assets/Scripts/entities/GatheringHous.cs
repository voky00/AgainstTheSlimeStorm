using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GatheringHous : MonoBehaviour
{
    public int cost;
    public int income;
    public int level;
    public int type;

    public GameObject LumberUp;
    public GameObject GoldUp;

    private float timer;
     
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 5)
        {
            timer = 0;
            AddResource();
        }
    }

    private void AddResource()
    {
        if (type == 0)
        {
            GameManager.Instance.AddLumber(income);
            GameObject lumberText = Instantiate(GameManager.Instance.LumberTextPrefab, GameObject.Find("Canvas").transform);
            lumberText.GetComponent<TextMeshProUGUI>().text = income.ToString();
        }
            
        else if (type == 1)
        {
            GameManager.Instance.AddMoney(income);
            GameObject moneyText = Instantiate(GameManager.Instance.MoneyTextPrefab, GameObject.Find("Canvas").transform);
            moneyText.GetComponent<TextMeshProUGUI>().text = income.ToString();
        }
            
    }


    public void Upgrade()
    {
        if (type == 0)
        {
            if (GameManager.Instance.Money >= cost)
            {
                GameManager.Instance.AddMoney(-cost);
                cost += 50;
                cost *= 2;
                income *= 2;
                level++;
                LumberUp.GetComponent<Tooltip>().OnPointerExit(null);
            }
        }
            else if (type == 1)
        {
            if (GameManager.Instance.Lumber >= cost)
            {
                GameManager.Instance.AddLumber(-cost);
                cost += 50;
                cost *= 2;
                income *= 2;
                level++;
                GoldUp.GetComponent<Tooltip>().OnPointerExit(null);
            }
        }
                

    }

    private void OnMouseDown()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && level <= 5)
        {
            //GameManager.Instance.selectedTile = gameObject;
            GameManager.Instance.UpgradeMenu.transform.position = Input.mousePosition + new Vector3(100, 70, 0);
            GameManager.Instance.UpgradeMenu.SetActive(true);
            GameManager.Instance.TowerMenu.SetActive(false);
            GameManager.Instance.TowerUpgradeMenu.SetActive(false);

            if (type == 0)
            {
                GoldUp.SetActive(false);
                LumberUp.SetActive(true);
                LumberUp.GetComponent<Tooltip>().message = "Lumber Mill lvl " + level + " cost: " + cost + "G";
            }                       
            else if (type == 1)
            {
                GoldUp.SetActive(true);
                LumberUp.SetActive(false);
                GoldUp.GetComponent<Tooltip>().message = "Gold Mine lvl " + level + " cost: " + cost + "W";
            }
                
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;


public class GameManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject selectedTile;
    public GameObject TowerMenu;
    public GameObject UpgradeMenu;
    public GameObject TowerUpgradeMenu;
    public GameObject MoneyTextPrefab;
    public GameObject LumberTextPrefab;

    public static GameManager Instance;
    public static int difficulty = 1;
    public int Money = 100;
    public int Lumber = 50;
    public int HP = 10;
    public Bar bar;

    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI lumberText;

    private void Update()
    {
        moneyText.text = "Gold: " + Money.ToString();
        lumberText.text = "Wood: " + Lumber.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
        
       
    }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int amount)
    {
        Money += amount;
        
    }
    public void AddLumber(int amount) 
    { 
        Lumber += amount;
        
    }
    
    public void DemageCastle(int amount)
    {
        HP -= amount;
        if(HP<0)HP = 0;
        bar.Set(HP);
        if (HP <= 0)
        {
            //todo
            Debug.Log("Game Over");
        }
    }

    public void TowerUpgrade()
    {
        Tower tower = selectedTile.GetComponent<Tower>();
        tower.Upgrade();
    }
    public void TowerSell()
    {
        Tower tower = selectedTile.GetComponent<Tower>();
        tower.Sell();
    }
}

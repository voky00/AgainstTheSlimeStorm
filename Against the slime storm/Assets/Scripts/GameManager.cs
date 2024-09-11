using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject selectedTile;
    public GameObject TowerMenu;
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

    public void SetMoney(int amount)
    {
        Money = amount;
    }
    public void SetLumber(int amount) 
    { 
        Lumber = amount;
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
}

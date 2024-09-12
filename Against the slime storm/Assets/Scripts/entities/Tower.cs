using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int Damage;
    public float AttackSpeed = 2;
    public int Hp;
    public int goldCost;
    public int woodCost;
    public Bullet bullet;
    public int type;
    private float timer;
    public int bulletSpeed = 100;
    public int level = 1;

    GameObject WallUp;
    GameObject ArrowUp;
    GameObject MagicUp;
    GameObject PremiumUp;

    private void Awake()
    {
        goldCost *= 3;
        woodCost *= 3;
         WallUp = GameManager.Instance.TowerUpgradeMenu.transform.GetChild(1).gameObject;
         ArrowUp = GameManager.Instance.TowerUpgradeMenu.transform.GetChild(2).gameObject;
         MagicUp = GameManager.Instance.TowerUpgradeMenu.transform.GetChild(3).gameObject;
         PremiumUp = GameManager.Instance.TowerUpgradeMenu.transform.GetChild(4).gameObject;
    }

    private void Update()
    {
        if (AttackSpeed != 0)
        {
            timer += Time.deltaTime;
            if (timer >= AttackSpeed)
            {
                Attack();
                timer = 0;
            }
        }
        
    }
    public void Attack()
    {
        
        Bullet bulet = Instantiate(bullet, transform.position + new Vector3(0,30,10), Quaternion.identity);
        bulet.tower = this;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
            Destroy(gameObject);   
    }

    public void Upgrade()
    {
        if (GameManager.Instance.Money >= goldCost && GameManager.Instance.Lumber >= woodCost)
        {
            GameManager.Instance.Money -= goldCost;
            GameManager.Instance.Lumber -= woodCost;
            level++;
            goldCost *= 3;
            woodCost *= 3;
            if (type == 0)
                Hp = level * 20;
            else
                Hp = level * 4;

            Damage *= 2;
            if(type == 0)
                WallUp.GetComponent<Tooltip>().OnPointerExit(null);
            else if (type == 1)
                ArrowUp.GetComponent<Tooltip>().OnPointerExit(null);
            else if (type == 2)
                MagicUp.GetComponent<Tooltip>().OnPointerExit(null);
            else if (type == 3)
                PremiumUp.GetComponent<Tooltip>().OnPointerExit(null);
        }
    }

    public void Sell()
    {
        GameManager.Instance.Money += goldCost / 6;
        GameManager.Instance.Lumber += woodCost / 6;
        Destroy(gameObject);
        GameManager.Instance.TowerUpgradeMenu.transform.GetChild(5).GetComponent<Tooltip>().OnPointerExit(null);
    }

    private void OnMouseDown()
    {
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() && level <= 5)
        {
            GameManager.Instance.selectedTile = gameObject;
            GameManager.Instance.TowerUpgradeMenu.transform.position = Input.mousePosition + new Vector3(100, 70, 0);
            GameManager.Instance.UpgradeMenu.SetActive(false);
            GameManager.Instance.TowerMenu.SetActive(false);
            GameManager.Instance.TowerUpgradeMenu.SetActive(true);

            if (type == 0)
            {
                WallUp.SetActive(true);
                ArrowUp.SetActive(false);
                MagicUp.SetActive(false);
                PremiumUp.SetActive(false);
                WallUp.GetComponent<Tooltip>().message = "Wall lvl " + level + " (*2Hp) cost: " + woodCost + "W " + goldCost + "G";
            }
            else if (type == 1)
            {
                WallUp.SetActive(false);
                ArrowUp.SetActive(true);
                MagicUp.SetActive(false);
                PremiumUp.SetActive(false);
                ArrowUp.GetComponent<Tooltip>().message = "Arrow Tower lvl " + level + " (*2dmg,*2Hp) cost: " + woodCost + "W " + goldCost + "G";
            }
            else if (type == 2)
            {
                WallUp.SetActive(false);
                ArrowUp.SetActive(false);
                MagicUp.SetActive(true);
                PremiumUp.SetActive(false);
                MagicUp.GetComponent<Tooltip>().message = "Magic Tower lvl " + level + " (*2dmg,*2Hp) cost: " + woodCost + "W " + goldCost + "G";
            }
            else if (type == 3)
            {
                WallUp.SetActive(false);
                ArrowUp.SetActive(false);
                MagicUp.SetActive(false);
                PremiumUp.SetActive(true);
                PremiumUp.GetComponent<Tooltip>().message = "Premium Tower lvl " + level + " (*2dmg,*2Hp) cost: " + woodCost + "W " + goldCost + "G";
            }
        }

    }
}

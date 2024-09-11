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
   
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= AttackSpeed)
        {
            Attack();
            timer = 0;
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
        {
            //GetComponentInParent<Tile>().tower = null;
            
            Destroy(gameObject);
        }
    }

    public void Upgrade()
    {
        //todo
    }
    
}

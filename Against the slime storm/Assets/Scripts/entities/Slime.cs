using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int Hp;
    public int Speed = 10;
    public int Damage = 10;
    public float AttackCooldown = 1;
    public int CastleDamage = 1;

    Tower targetTower;
    public int row=1;
    private int targetTile=9;
    public GameObject nextTarget;

    private void Awake()
    {
        nextTarget = GameObject.Find("Spawn");
    }
    private void Update()
    {

        if (nextTarget.GetComponent<Tile>() != null)
            targetTower = nextTarget.GetComponent<Tile>().tower;



        if (targetTower != null)
        {
            AttackCooldown -= Time.deltaTime;
            if (AttackCooldown <= 0)
            {
                Attack();
                AttackCooldown = 1;
            }
        }
        else        
            Move();

    }
    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0)
        {
            //todo
            Destroy(gameObject);
        }
    }
    public void Move()
    {
        //move towards nextTarget in Z X axis
        //if reached nextTarget, set nextTarget to next tile in path
        //if reached end of path, call CastleDamage()
        //implement
        //Debug.Log("Moving");
        transform.position = Vector3.MoveTowards(transform.position, nextTarget.transform.position, Speed * Time.deltaTime);
        if (transform.position == nextTarget.transform.position)
        {
            targetTile--;
            if (targetTile == 0)
            {
                nextTarget = GameObject.Find("GateTile");

            }else if (targetTile == -1)
            {
                nextTarget = GameObject.Find("EndTile");
            }else if (targetTile <= -2)
            {
                GameManager.Instance.DemageCastle(CastleDamage);                
                Destroy(gameObject);
            }
            else
            {
                
                nextTarget = GameObject.Find("Tile " + row + "-" + targetTile);
                //Debug.Log(nextTarget);
            }
            
        }

    }
    public void Attack()
    {
        //Debug.Log(targetTower.Hp);
        targetTower.TakeDamage(Damage);
    }
  
}

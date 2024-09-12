using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Tower tower;

    // when enter the trigger area destroy the bullet and deal damage to the enemy

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * tower.bulletSpeed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Slime>().TakeDamage(tower.Damage);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}

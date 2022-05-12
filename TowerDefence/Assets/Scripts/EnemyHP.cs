using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float health;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        { 
            Die();
        }
    }
    private void Die()
    {
        SpawnEnemy.rep++;
        TowerManager.money++;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            Destroy(gameObject);
        }
    }
}

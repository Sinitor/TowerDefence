using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float radius;
    private Transform target;
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float fireCountDown = 0f;
    public string enemyTag = "Enemy";
    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    private void Update()
    {
        if (target == null)
        {
            return;
        }

        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }
        fireCountDown -= Time.deltaTime;
    }
    private void UpdateTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemys)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= radius)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }
    private void Shoot()
    {
        GameObject projectileGo = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        Projectile rojectile = projectileGo.GetComponent<Projectile>();
        if (rojectile != null)
        {
            rojectile.Seek(target);
        }
    } 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{

    [SerializeField] float attackRange = 10f;
    [SerializeField]float attackInterval = 1f;

    [SerializeField] GameObject player;

    // Prefab for the projectile
    [SerializeField] GameObject projectilePrefab;

    float attackIntervalTime = 0f;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        attackIntervalTime+=Time.deltaTime;
 
        if (distance < attackRange && attackIntervalTime > attackInterval)
        {
            Attack();
            attackIntervalTime=0f;
        }
    }

    void Attack()
    {
        // Calculate the direction towards the player
        Vector2 direction = player.transform.position - transform.position;

        // Instantiate the projectile and fire it towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectile.GetComponent<EnemyBullet>().speed;
    }

}

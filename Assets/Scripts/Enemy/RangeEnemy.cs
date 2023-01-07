using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{   [SerializeField]float playerFollowingRange=30f;
    [SerializeField]float moveSpeed=10f;
    [SerializeField] float attackRange = 10f;
    [SerializeField]float attackInterval = 1f;

    [SerializeField] GameObject player;

    // Prefab for the projectile
    [SerializeField] GameObject projectilePrefab;

    float attackIntervalTime = 0f;

    public bool isPlayerRange = false;

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        attackIntervalTime+=Time.deltaTime;
        if(distance<playerFollowingRange && playerFollowingRange >= attackRange){
            isPlayerRange = true;
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position + new Vector3(5f,5f,5f),moveSpeed*Time.deltaTime);
        }
        else{
            isPlayerRange = false;
        }
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
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = direction.normalized * projectile.GetComponent<EnemyBullet>().speed;
    }

}

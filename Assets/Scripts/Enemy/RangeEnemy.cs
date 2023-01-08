using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : MonoBehaviour
{   
    [SerializeField]float playerFollowingRange=30f;
    [SerializeField]float unfollowingDistence = 6f;
    [SerializeField]float moveSpeed=10f;
    [SerializeField] float attackRange = 10f;
    [SerializeField]float attackInterval = 1f;

    [SerializeField] Transform player;

    // Prefab for the projectile
    [SerializeField] GameObject projectilePrefab;

    float attackIntervalTime = 0f;

    public bool isPlayerRange = false;
    bool facingRight = true;

    void Start(){
        player = FindObjectOfType<PlayerMovement>().transform;

    }
    void Update()
    {
        if(transform.position.x<player.position.x && facingRight){
            Flip();
        }
        else if(transform.position.x>player.position.x && !facingRight){
            Flip();
        }
        float distance = Vector2.Distance(transform.position, player.position);
        
        attackIntervalTime+=Time.deltaTime;
        if(distance<playerFollowingRange && playerFollowingRange >= attackRange){
            GetComponent<FlyingEnemy>().enabled = false;
            isPlayerRange = true;
            transform.position = Vector2.MoveTowards(transform.position,player.transform.position + new Vector3(unfollowingDistence,2f,0f),moveSpeed*Time.deltaTime);
        }
        else{
            isPlayerRange = false;
            GetComponent<FlyingEnemy>().enabled = true;
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
    void Flip(){
        facingRight = !facingRight;
         transform.Rotate(0f,180f,0f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField]float speed=8f;
    [SerializeField]float attactRange=3f;
    [SerializeField] float attackDelay=1f;
    float attackTimer = 0;
    
    Rigidbody2D rb;
    Transform targetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPlayer = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,targetPlayer.position)<=attactRange){
            attackTimer+=Time.deltaTime;
            if(attackTimer>=attackDelay){
                //enemy will attack
                attackTimer = 0;
            }
        }
        else{
            Vector2 direction = (targetPlayer.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}

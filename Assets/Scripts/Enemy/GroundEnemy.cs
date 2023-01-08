using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float startWaitTime = 1f;
    float waitTime;

    [SerializeField] Transform movePosition;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField]float giveDamage = 5f;

    bool facingRight=true;
    void Start()
    {
        waitTime = startWaitTime;
        movePosition.position = new Vector2(Random.Range(minX, maxX), transform.position.y);
    }


    void Update()
    {
        if(transform.position == movePosition.position)
            movePosition.position = new Vector2(Random.Range(minX, maxX), transform.position.y);

        transform.position = Vector2.MoveTowards(transform.position, movePosition.position, moveSpeed * Time.deltaTime);
        
        if(transform.position.x > movePosition.position.x && facingRight){
            Flip();
        }
        else if(transform.position.x<movePosition.position.x && !facingRight){
            Flip();
        }
    }

    void Flip(){
        facingRight = !facingRight;
         transform.Rotate(0f,180f,0f);
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if(player){
            player.TakeDamage(giveDamage);
        }
    }
}

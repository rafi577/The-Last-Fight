using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float startWaitTime = 1f;
    float waitTime;

    [SerializeField] Transform movePosition;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY,maxY;

    Rigidbody2D rb;
    bool facingRight=true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        movePosition.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY,maxY));
    }


    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePosition.position, moveSpeed * Time.deltaTime);
        if(transform.position.x > movePosition.position.x && facingRight){
            Flip();
        }
        else if(transform.position.x<movePosition.position.x && !facingRight){
            Flip();
        }
        if (waitTime <= 0)
        {
            waitTime = startWaitTime;
            movePosition.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY,maxY));
        }
        else
        {
            waitTime -= Time.deltaTime;
        }


        
        
    }
    void Flip(){
        facingRight = !facingRight;
         transform.Rotate(0f,180f,0f);
    }
}

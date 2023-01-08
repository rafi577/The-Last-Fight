using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    [Header("Movement")]
    [SerializeField]float moveSpeed = 10f;
    [SerializeField]float jumpForce;
    [SerializeField]Animator anim;
    float moveInput;

    //jump
    [Header("Jump")]
    [SerializeField]float jumpTime=.3f;
    [SerializeField]float coyoteTime = .2f;
    float coyoteTimeCount = 0;
    float jumpCountTime=0f;
    bool isGround = true,isJumping = false;
    [SerializeField]float numberOfJump=2;
    float jumpImade = 0;
    [SerializeField]Transform  feetPosition;
    [SerializeField]float checkRadius;
    [SerializeField]LayerMask WhatIsGround;


    //my gravity

    [Header("Gravity")]
    [SerializeField]float flyGravity = 10f;
    [SerializeField]float fallGravity = 20f;


    [Header("Air Controll")]
    [SerializeField] float airControlForce = 10f;
    [SerializeField]float maxAirSpeed = 10f;


    bool isPlayerBusyWithConversition=false;

    bool facingRight = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate(){
        if(!isPlayerBusyWithConversition){
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * moveSpeed,rb.velocity.y);
            FlipDir();
        }
        
    }

    void Update(){
        isPlayerBusyWithConversition = FindObjectOfType<DialougeTrigger>().isDialougeOpen;

        if(!isPlayerBusyWithConversition){
            Jump();
            AirMovement();
        }
        else {
            rb.velocity = Vector2.zero;
        }

        PlayerAnimation();
    }

    void AirMovement(){
        if(!isGround){
            float input = Input.GetAxis("Horizontal");
            Vector2 force = Vector2.right * input * airControlForce;
            rb.AddForce(force);

            // Limit the player's air speed
            if (rb.velocity.x > maxAirSpeed)
            {
                rb.velocity = new Vector2(maxAirSpeed, rb.velocity.y);
            }
            else if (rb.velocity.x < -maxAirSpeed)
            {
                rb.velocity = new Vector2(-maxAirSpeed, rb.velocity.y);
            }
        }
    }
    void PlayerAnimation(){
        if(isPlayerBusyWithConversition){
            anim.SetBool("isPlayerRunning",false);
        }
        else if(moveInput!=0){
            anim.SetBool("isPlayerRunning",true);
        }
        else{
            anim.SetBool("isPlayerRunning",false);
        }
        //if(Input.GetKeyDown(KeyCode.Space)){
       //     anim.SetTrigger("takeOff");
        //}
      //  if(!isGround){
       //     anim.SetBool("isPlayerJumping",true);
       // }
       // else{
        //    anim.SetBool("isPlayerJumping",false);
       // }

    }

    void Move(){
        //rb.velocity = new Vector2(horizontalInput * data.maxSpeed ,rb.velocity.y);
    }
    void Jump(){
        //float jumpForce = Mathf.Sqrt(data.jumpHeight * (Physics2D.gravity.y*rb.gravityScale)*-2);
        //rb.AddForce(Vector2.up * jumpForce,ForceMode2D.Impulse);
        isGround = Physics2D.OverlapCircle(feetPosition.position,checkRadius,WhatIsGround);
        if(isGround){
            coyoteTimeCount = coyoteTime;
        }
        else{
            coyoteTimeCount-=Time.deltaTime;
        }
        if((isGround || coyoteTimeCount>0) && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpCountTime = 0;
        }
        if(Input.GetKey(KeyCode.Space) && isJumping){
            jumpCountTime+=Time.deltaTime;
            if(jumpCountTime<jumpTime){
                rb.velocity = Vector2.up * jumpForce;
            }
            else isJumping = false;
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            isJumping = false;
            coyoteTimeCount=0;
        }

        if(rb.velocity.y>0){
            rb.gravityScale = flyGravity;
        }
        else if(!isGround){
            rb.gravityScale = fallGravity;
        }
    }


    
    void FlipDir(){
        if(facingRight && rb.velocity.x>0){
            Flip();
        }
        else if(!facingRight && rb.velocity.x<0){
            Flip();
        }
    }
    void Flip(){
        facingRight = !facingRight;
         transform.Rotate(0f,180f,0f);
    }

    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Teleportor"){
            transform.position = FindObjectOfType<Teleportor>().teleportor.position;
        }
        
    }
    void OnTriggerEnter2D(Collider2D hitInfo){
        Teleportor tp = hitInfo.GetComponent<Teleportor>();
        if(tp){
            transform.position = tp.teleportor.position;
        }
        if(hitInfo.gameObject.tag=="shouldEnemySpawn"){
            FindObjectOfType<EnemySpanwer>().isSpawnEnemy= true;
        }
    }
}

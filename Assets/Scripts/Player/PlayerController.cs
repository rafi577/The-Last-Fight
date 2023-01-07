using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]float moveSpeed,jumpForce;
    [SerializeField]GameObject playerShadow;
    float horizontalMove,jumped;

    bool facingRight = true,isGround = true;
    Rigidbody2D rb2d;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        jumped = Input.GetAxis("Jump");
        
    }

    void FixedUpdate(){

        if(facingRight && rb2d.velocity.x<0){
            Flip();
        }
        else if(!facingRight && rb2d.velocity.x>0){
            Flip();
        }
        PlayerMovement();

        if(jumped>0 && isGround){
            playerJump();
        }
    }

    void PlayerMovement(){
        rb2d.velocity = new Vector2(horizontalMove * moveSpeed * Time.fixedDeltaTime,rb2d.velocity.y);
        
        if(horizontalMove!=0){
            playerAnim.SetBool("isRuning",true);
        }
        else{
            playerAnim.SetBool("isRuning",false);
        }
        
    }
    void playerJump(){
        rb2d.velocity = Vector2.up * jumpForce;
        playerAnim.SetBool("isJumped",true);
        isGround = false;
        playerShadow.SetActive(false);
        
    }
    void Flip(){
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Ground"){
            isGround = true;
            playerAnim.SetBool("isJumped",false);
            playerShadow.SetActive(true);
        }
    }
}

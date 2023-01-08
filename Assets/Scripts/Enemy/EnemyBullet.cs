using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]GameObject explasionPartical;
    public float speed=10f;
    [SerializeField]float lifeTime = 2f;
    Rigidbody2D rb;

    void Start(){
        
        rb = GetComponent<Rigidbody2D>();
    }
    public void bulletDir(Vector2 dir){
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        lifeTime-=Time.deltaTime;
        if(lifeTime<0){
            destroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if(player){
            player.TakeDamage(8f);
            destroyBullet();
        }
        if(hitInfo.gameObject.tag=="Ground"){
            destroyBullet();
        }
    }

    void destroyBullet(){
        Destroy(gameObject);
        FindObjectOfType<ScreenShake>().Shake();
        Instantiate(explasionPartical,transform.position,transform.rotation);
    }
}

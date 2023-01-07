using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]GameObject explasionPartical;
    [SerializeField]float speed=10f;
    [SerializeField]float lifeTime = 2f;
    Rigidbody2D rb;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
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
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if(enemy){
            enemy.TakeDamage(20f);
        }
        destroyBullet();
    }

    void destroyBullet(){
        Destroy(gameObject);
        FindObjectOfType<ScreenShake>().Shake();
        Instantiate(explasionPartical,transform.position,transform.rotation);
    }
}

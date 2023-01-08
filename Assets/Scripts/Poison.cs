using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    [SerializeField]GameObject dieEffect;
    [SerializeField]float lifeTime=10f;
    [SerializeField]float minSpeed = 5f,maxSpeed=10;
    Transform playerPositon;
    void Start(){
        Destroy(gameObject,lifeTime);
        playerPositon = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update(){
        transform.position = Vector2.MoveTowards(transform.position,playerPositon.position,Random.Range(minSpeed,maxSpeed)*Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();
        if(player){
            player.TakeDamage(10f);
            DestroyPoison();
        }
        if(hitInfo.gameObject.tag=="bullet"){
            DestroyPoison();
        }
    }

    void DestroyPoison(){
        Destroy(gameObject);
        Instantiate(dieEffect,transform.position,transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderPower : MonoBehaviour
{
    [SerializeField]Transform player;
    [SerializeField]GameObject poison;
    [SerializeField]Transform poisonSpawnPosition;

    [SerializeField]float attactRange = 15f;
    [SerializeField]float attackInterval=2f;
    float attackTime=0;
    void Start(){
        player = FindObjectOfType<PlayerMovement>().transform;
    }
    void Update(){
        attackTime+=Time.deltaTime;
        float distance = Vector2.Distance(transform.position,player.position);
        if(attackTime>=attackInterval && distance <= attactRange){
            Instantiate(poison,poisonSpawnPosition.position,poisonSpawnPosition.rotation);
            attackTime=0;
        }
    }


}

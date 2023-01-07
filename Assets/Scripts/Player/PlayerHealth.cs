using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
     public float playerHealth = 100f;
    //[SerializeField]GameObject playerDieParticalEffect;

    public void TakeDamage(float damage){
        playerHealth-=damage;
        if(playerHealth <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
        //die effect;
    }
}

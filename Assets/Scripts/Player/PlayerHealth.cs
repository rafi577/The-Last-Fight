using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
     public float playerHealth = 100f;
     [SerializeField] Slider healthSlider;
    float curHealth;
    //[SerializeField]GameObject playerDieParticalEffect;



    void Start(){
        healthSlider.value = playerHealth;
        curHealth = playerHealth;
    }

    public void TakeDamage(float damage){
        playerHealth-=damage;
        curHealth-=damage;
        healthSlider.value = curHealth;
        playerHealth-=damage;
        if(playerHealth <= 0){
            Die();
        }
    }

    void Die(){
        
        Destroy(gameObject);
        //die effect;

        FindObjectOfType<GameManager>().GameOver();
    }
}

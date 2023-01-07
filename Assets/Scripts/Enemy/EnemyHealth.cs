using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth = 100f;
    [SerializeField] Slider healthSlider;
    float curHealth;
    //[SerializeField]GameObject enemyDieParticalEffect;

    void Start(){
        healthSlider.value = enemyHealth;
        curHealth = enemyHealth;
    }

    public void TakeDamage(float damage){
        enemyHealth-=damage;
        curHealth-=damage;
        healthSlider.value = curHealth;
        if(enemyHealth <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
        //die effect;
    }
}

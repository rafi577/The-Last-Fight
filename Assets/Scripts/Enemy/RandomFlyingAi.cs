using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFlyingAi : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]float minimumSpeed = 2f;
    [SerializeField]float maximumSpeed = 5f;

    [Header("Direction Changing Movement")]
    [SerializeField]float minimumTime=2f;
    [SerializeField]float maximumTime=5f;
    float changeDirectionInterval;

    Rigidbody2D rb;
    float changeDirectionTime=0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        changeDirectionInterval = Random.Range(minimumTime,maximumTime);
    }

    // Update is called once per frame
    void Update()
    {
        changeDirectionTime+=Time.deltaTime;
        if(changeDirectionTime>=changeDirectionInterval){
           // changeDirectionInterval = Random.Range(minimumTime,maximumTime);
            float angle = Random.Range(0,360f);
            float speed = Random.Range(minimumSpeed,maximumSpeed);
            rb.velocity = Quaternion.Euler(0f,0f,angle) * Vector2.up * speed;
        }
    }
}

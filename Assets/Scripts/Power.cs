using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    [SerializeField]float lifeTime=2f;
    float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time +=Time.deltaTime;
        if(lifeTime<time){
            Destroy(gameObject);
            return;
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if(player){
            FindObjectOfType<LevelProgressBar>().LevelProgressing(10f);
            DestroyPower();
        }
    }

    void DestroyPower(){
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    [SerializeField]Transform enemySpawnPosition;
    [SerializeField]GameObject[] enemys;
    [SerializeField]float spawnInterval = 5f;
    [HideInInspector]public bool isSpawnEnemy = false;
    float spawnTime=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isSpawnEnemy){
            spawnTime+=Time.deltaTime;
            if(spawnTime>=spawnInterval){
                SpawnEnemy();
                spawnTime=0;
            }
        }
    }

    void SpawnEnemy(){
        int index = Random.Range(0,enemys.Length);
        Instantiate(enemys[index],enemySpawnPosition.position,Quaternion.identity);
    }
}

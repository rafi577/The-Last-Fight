using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class BulletShoot : MonoBehaviour
{
    [SerializeField]Transform firePoint;
    [SerializeField]GameObject bullet;
    [SerializeField]AudioClip shootSound;
    

    bool isPlayerBusyWithConversition = false;
    void Update()
    {
        isPlayerBusyWithConversition = FindObjectOfType<DialougeTrigger>().isDialougeOpen;
        if(Input.GetMouseButtonDown(0) && !isPlayerBusyWithConversition){
            Instantiate(bullet,firePoint.position,firePoint.rotation);
            
        }
        
    }
}

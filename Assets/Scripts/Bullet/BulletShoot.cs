using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField]Transform firePoint;
    [SerializeField]GameObject bullet;

    


    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            Instantiate(bullet,firePoint.position,firePoint.rotation);
        }
        
    }
}

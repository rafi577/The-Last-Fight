using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    [SerializeField]Vector3 offset = new Vector3(0,0,-10);
    [SerializeField]float smoothTime = .25f;
    Vector3 velocity = Vector3.zero;

    [SerializeField]Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = target.position+offset;
        transform.position = Vector3.SmoothDamp(transform.position,targetPosition,ref velocity,smoothTime);
    }
}

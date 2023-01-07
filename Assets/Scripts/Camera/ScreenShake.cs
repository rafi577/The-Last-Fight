using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [SerializeField] float duration = 1f;

    public void Shake(){
        StartCoroutine(Shaking());
    }

    IEnumerator Shaking(){
        Vector3 startPosition = transform.position;
        float shakingTime = 0f;
        while(shakingTime<duration){
            shakingTime+=Time.deltaTime;
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = startPosition;
    }
}

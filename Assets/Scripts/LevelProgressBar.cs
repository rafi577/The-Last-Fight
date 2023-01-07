using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelProgressBar : MonoBehaviour
{
    [SerializeField]float needPowerToCompleteLevel;
    [SerializeField]Slider progressBar;

    float curProgress=0;

    public float getCurrentProgress(){
        return curProgress;
    }
    void Start(){
        progressBar.value = curProgress;
    }

    public void LevelProgressing(float power){
        power/=2;
        curProgress +=power;
        Debug.Log(power);
        //Debug.Log(curProgress);
        progressBar.value = curProgress;

        if(curProgress >= 100){
            SceneManager.LoadScene(3);
        }
    }
}

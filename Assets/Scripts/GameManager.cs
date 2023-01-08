using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pauseAndPlay;
    [SerializeField] GameObject pausePanel;
    public void Play(){
        SceneManager.LoadScene(1);
    }

    public void Quit(){
        Application.Quit();
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void Pause(){
        Time.timeScale = 1-Time.timeScale;
        if(Time.timeScale==0){
            pauseAndPlay.text = "Play";
            pausePanel.SetActive(true);
        }
        else{
            pauseAndPlay.text = "Pause";
            pausePanel.SetActive(false);
        }
    }
    public void GameOver(){
         SceneManager.LoadScene(2);
    }


    public void NextLevel(){
        SceneManager.LoadScene(2);
    }

    public void PlayAgain(string path){
        SceneManager.LoadScene(path);
    }
}

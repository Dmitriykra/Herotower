using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameState : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject pauseScreen;
    [SerializeField] GameObject startScreen;

    private void Awake()
    {
        LoadingScreen();
    }
    void LoadingScreen(){
        Time.timeScale = 0;
        startScreen.SetActive(true);
    }
    public void StartScreen(){
        startScreen.SetActive(false);
        Time.timeScale = 1;
    }


    public void RestartGame(){
        loseScreen.SetActive(false);
        winScreen.SetActive(false);
        pauseScreen.SetActive(false);
        startScreen.SetActive(false);

        Time.timeScale = 1;
        //получаем текущую сцену
        Scene curretScene = SceneManager.GetActiveScene();
        //перезагружаемэту текущую сцену по индексу
        SceneManager.LoadScene(curretScene.buildIndex);
    }

    public void LoseGame(){
        loseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinGame(){
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseGame(){
        if(pauseScreen.activeInHierarchy){
            ReturnGame();
        } else {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        } 
    }

    public void ReturnGame(){
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame(){
        Application.Quit();
    }
}

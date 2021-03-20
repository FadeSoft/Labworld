using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 2f;

    public GameObject compeleteLevelUI;

    public GameObject pausePnl;

    public void CompleteLevel()
    {
        Debug.Log("LEVEL WON");
        SceneManager.LoadScene(2);
    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", 2f);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void ShowHidePanel(bool status)
    {
        pausePnl.gameObject.SetActive(status);
    }


    public void PauseResumeGame()
    {
        bool durum = Time.timeScale == 0;
        ShowHidePanel(!durum);
        if (durum)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void sss()
    {

        Time.timeScale = 0f;

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        Time.timeScale = 1;

    }
    public void Episodes()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
    }
    public void Resume()
    {
        pausePnl.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }




}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CountDownLab : MonoBehaviour
{
    public float timeLeft;

    public GameObject gameOverPnl;
    public GameObject gameOverPnl2;

    public Text TimeText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        TimeText.text = "Kalan Süre:" + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Time.timeScale = 0;
            gameOverPnl.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            gameOverPnl.SetActive(false);
        }
    }
    public void zamanarttı()
    {
        timeLeft = timeLeft + 40;
        gameOverPnl.SetActive(false);
        gameOverPnl2.SetActive(false);

        Time.timeScale = 1;
    }
}

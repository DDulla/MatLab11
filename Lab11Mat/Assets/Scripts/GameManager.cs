using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject bird;
    public float upperBound = 10f;
    public float lowerBound = -10f;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI scoreText;
    private float startTime;
    private bool isGameOver = false;

    void Start()
    {
        startTime = Time.time;
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            if (bird.transform.position.y > upperBound || bird.transform.position.y < lowerBound || bird.transform.position.x < -20)
            {
                GameOver();
            }
            UpdateTimer();
        }
    }

    void UpdateTimer()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerText.text = minutes + ":" + seconds;
    }

    void GameOver()
    {
        isGameOver = true;
        float finalTime = Time.time - startTime;
        string minutes = ((int)finalTime / 60).ToString();
        string seconds = (finalTime % 60).ToString("f2");
        scoreText.text = "Time played: " + minutes + "." + seconds;
        gameOverPanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu"); 
    }
}

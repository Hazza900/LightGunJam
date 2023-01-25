using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FrightController : MonoBehaviour
{
    public float maximumFright;
    public float frightLevel;
    
    [Range(0, 1)] public float GameOverThreshold;
    public float gameOverCountdownDuration;
    public float gameOverCountdownRemaining;

    private bool gameOverCountdownInProgress;
    public bool gameOver;

    private void Start()
    {
        gameOverCountdownRemaining = gameOverCountdownDuration;
    }

    void Update()
    {
        if (!gameOver)
        {
            if (gameOverCountdownInProgress)
                GameOverCountdown();

            GameOverCheck();
        }
    }

    private void GameOverCountdown()
    {
        if (gameOverCountdownRemaining > 0)
        {
            gameOverCountdownRemaining -= Time.deltaTime;
            Debug.Log(gameOverCountdownRemaining);
        }
        else
        {
            gameOverCountdownInProgress = false;
            gameOver = true;
            GameOver();
        }
    }

    private void GameOverCheck()
    {
        float gameOverFrightLevel = maximumFright * GameOverThreshold;

        if (gameOverCountdownInProgress)
        {
            if (frightLevel < gameOverFrightLevel)
            {
                gameOverCountdownInProgress = false;
            }
        }    

        if (!gameOverCountdownInProgress && frightLevel > gameOverFrightLevel)
        {
            gameOverCountdownRemaining = gameOverCountdownDuration;
            gameOverCountdownInProgress = true;
        }
    }

    public void AddFright(float value)
    {
        frightLevel += value;
    }

    public void RemoveFright(float value)
    {
        frightLevel -= value;
    }

    public void GameOver()
    {

    }
}

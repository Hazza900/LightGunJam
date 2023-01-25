using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int currentScore = 0;
    [SerializeField]
    TextMeshProUGUI scoreCounter;

    private void Start()
    {
        scoreCounter.text = currentScore.ToString();
    }

    public void AddPoints(int amountToAdd)
    {
        currentScore += amountToAdd;
        UpdateScore();
        
    }

    public void RemovePoints(int amountToRemove)
    {
        currentScore -= amountToRemove;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreCounter.text = currentScore.ToString();
    }
}

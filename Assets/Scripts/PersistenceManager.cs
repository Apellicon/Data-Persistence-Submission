using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    private int highScore;
    private int currentScore;
    private string playerName;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerName(string pName)
    {
        playerName = pName;
    }

    public string GetPlayerName()
    {
        return playerName;
    }

    public void SaveScore()
    {
        // Save score
        //currentScore = score;

        // Save high score if needed
        if (currentScore > highScore)
            highScore = currentScore;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void SetScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}

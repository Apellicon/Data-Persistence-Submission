using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _game_Canvas : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI currentscoreText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScores();
    }
        
    public void UpdateScores()
    {
        int _highcore = FindObjectOfType<PersistenceManager>().GetHighScore();

        if (_highcore > 0)
        {
            // Get previous highscore
            highscoreText.text = "High Score: " + _highcore.ToString() + " - " + FindObjectOfType<PersistenceManager>().GetHighScoreName();
        }
        else
        {
            highscoreText.text = "";
        }

        currentscoreText.text = "Score: " + FindObjectOfType<PersistenceManager>().GetScore();
    }
}

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScores()
    {
        highscoreText.text = "High Score: " + FindObjectOfType<PersistenceManager>().GetHighScore() + " - Name: " + FindObjectOfType<PersistenceManager>().GetPlayerName();
        currentscoreText.text = "Score: " + FindObjectOfType<PersistenceManager>().GetScore();
    }
}

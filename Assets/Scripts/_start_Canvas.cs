using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class _start_Canvas : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;
    public TMP_InputField NameText;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PersistenceManager>().LoadDataFromDisk();

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
    }

    public void ButtonExitGame()
    {        
// save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }

    public void ButtonStartGame()
    {
        //Save Player name
        FindObjectOfType<PersistenceManager>().SavePlayerName(NameText.text);

        // Start game
        FindObjectOfType<ScreensManager>().Restart();
    }
}

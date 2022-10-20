using System.Collections;
using System.Collections.Generic;
using System.IO;
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

        //LoadDataFromDisk();
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
        ///Debug.Log("Current: " + currentScore + " High: " + highScore);
        // Save high score if needed
        if (currentScore > highScore)
        {
            //Debug.Log("Saving score");
            highScore = currentScore;
        }
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

    [System.Serializable]   // ------------------------ SAVING AND LOADING ---------------------------
    class SaveData
    {
        public string highscoreName;
        public int highScore;
    }

    public void SaveDataToDisk()
    {
        Debug.Log("Saving to disk");
        SaveData data = new SaveData();
        data.highscoreName = playerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadDataFromDisk()
    {
        Debug.Log("Reading from disk");
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.highscoreName;
            highScore = data.highScore;
        }
    }

}

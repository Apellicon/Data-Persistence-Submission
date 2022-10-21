using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistenceManager : MonoBehaviour
{
    private int highScore;
    private string highscoreName;

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

    public void RememberScore()
    {
        // Save high score if needed
        if (currentScore > highScore)
        {
            Debug.Log("PersistenceManager.SaveScore");
            highScore = currentScore;
            highscoreName = playerName;

            SaveDataToDisk();
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

    public void ResetScore()
    {
        currentScore = 0;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public string GetHighScoreName()
    {
        return highscoreName;
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
        data.highscoreName = highscoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        //File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string strWorkPath = System.IO.Path.GetDirectoryName(strExeFilePath);
        File.WriteAllText(strWorkPath + "/savefile.json", json);
    }

    public void LoadDataFromDisk()
    {
        Debug.Log("Reading from disk");

        string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string path = System.IO.Path.GetDirectoryName(strExeFilePath) + "/savefile.json";
        //string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highscoreName = data.highscoreName;
            highScore = data.highScore;
        }
    }

}

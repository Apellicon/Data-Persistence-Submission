using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreensManager : MonoBehaviour
{
    private int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void NextScene()
    {
        int nextLevel = sceneNumber + 1;

        if(nextLevel < SceneManager.sceneCountInBuildSettings)
        {
            LoadScene(nextLevel);
        }        
    }

    public void Restart()
    {
        sceneNumber = -0;

        NextScene();
    }

    private void LoadScene(int scene)
    {
        sceneNumber = scene;
        FindObjectOfType<PersistenceManager>().ResetScore();
        SceneManager.LoadScene(scene);
    }
}

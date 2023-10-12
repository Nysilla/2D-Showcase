using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    int soulCount = 0;
    [SerializeField] int winCount = 2;
    string sceneName;

    void Start()
    {
        GetComponent<Canvas>().enabled = true;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

    }

    void Update()
    {

        if (soulCount >= winCount)
        {
            soulCount = 0;
            if (sceneName == "Level1")
            {
                SceneManager.LoadScene("Level2");
            }
            else if (sceneName == "Level2")
            {
                GetComponent<Canvas>().enabled = true;
            }
        }
    }
    public void PlayAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}

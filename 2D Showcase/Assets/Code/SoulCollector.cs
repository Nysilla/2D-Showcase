using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SoulCollector : MonoBehaviour
{
    int soulCount = 0;
    [SerializeField] int winCount = 2;
    [SerializeField] TextMeshProUGUI myText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Soul")
        {
            Destroy(collision.gameObject);
            soulCount++;
            myText.text = "Souls: " + soulCount;
        }
    }
    void Start()
    {

    }

    void Update()
    {
        
        if (soulCount >= winCount)
        {
            soulCount = 0;
            int currentScreenIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScreenIndex+1);
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

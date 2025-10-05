using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.IO;

public class FinishLevelScript : MonoBehaviour
{

    public GameObject finishLevelScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finishLevelScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Don't need this
    }

    public void DisplayFinishLevelScreen(int score, int level)
    {
        finishLevelScreen.SetActive(true);
        saveScore(score, level);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene + 1);
    }

    void saveScore(int score, int level)
    {
        // When the level is complete, we need to save the scores the player got in to PlayerPrefs
        // We need to save the users score and the level they completed it on

        // Update the level that the player is now up to since finishing this level
        PlayerPrefs.SetInt("lvlAt", level + 1);

        // Check if the player achieved a high score for this level
        string key = "HighScore_Level" + level;

        int currentScore = PlayerPrefs.GetInt(key, 0);

        if (score >= currentScore)
        {
            // If score is greater than the current high score, we need to replace the value
            Debug.Log("Replacung high score " + currentScore + " with new score " + score);
            // Update the score in PlayerPrefs
            PlayerPrefs.SetInt(key, score);
        }
    }
}

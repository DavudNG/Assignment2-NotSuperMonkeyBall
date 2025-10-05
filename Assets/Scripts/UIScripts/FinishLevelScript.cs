using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.IO;

/*
    FinishLevelScript.cs
    Author: Angus (Based on Julians UI scripts)
    Desc: Manage the finish level script. This manages showing the UI for the level complete screen,
        as well as saving the players score and level progress to PlayerPrefs.
*/
public class FinishLevelScript : MonoBehaviour
{

    // Initiate the actual Panel which contains all of the UI we need to show
    public GameObject finishLevelScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Make sure the finish level screen is not visible when the scene is started
        finishLevelScreen.SetActive(false);
    }

    // This function is called externally when the player completes the level by touching the Finish Flag
    // The score at the end of the level and the level number are passed in
    public void DisplayFinishLevelScreen(int score, int level)
    {
        // Display the finish level screen
        finishLevelScreen.SetActive(true);
        // Call the saveScore function and pass in the score and level values
        saveScore(score, level);
        // Pause the game by settting the time scale to 0
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        // Make sure the time is resumed after restarting the game
        Time.timeScale = 1f;
        // This loads the current scene again, replacing the current instance of the level
        // This gives the illusion of a "restart"
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // This handles the main menu
    // Pressing on this button will route the user to the main menu
    public void MainMenu()
    {
        // Make sure the games time scale is resumed
        Time.timeScale = 1f;
        // Load the main menu scene, which is at index 0 in the build settings
        SceneManager.LoadScene(0);
    }

    // This handles the next level button
    // Pressing on this button will route the user to the next level
    // This code cannot be run from the last level, as there is no "next" level to go to
    public void NextLevel()
    {
        // To load the next level, we need to get the current scene index
        // This is the level index used in unity's routing
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        // Make sure the games time scale is resumed before playing the next level
        Time.timeScale = 1f;
        // Load the next level by loading the scene with the current index + 1, or the 'next' scene
        SceneManager.LoadScene(currentScene + 1);
    }

    // This funntion is called when the script starts, or when the player completes the level
    // It saves the players score and level progress to PlayerPrefs
    void saveScore(int score, int level)
    {
        // When the level is complete, we need to save the scores the player got in to PlayerPrefs
        // We need to save the users score and the level they completed it on

        // Update the level that the player is now up to since finishing this level
        PlayerPrefs.SetInt("lvlAt", level + 1);

        // Check if the player achieved a high score for this level
        string key = "HighScore_Level" + level;

        // Get the current high score for this level, defaulting to 0 if it doesn't exist
        int currentScore = PlayerPrefs.GetInt(key, 0);

        // This conditional runs if the player achieved a score higher than the current record
        if (score >= currentScore)
        {
            // If score is greater than the current high score, we need to replace the value
            Debug.Log("Replacung high score " + currentScore + " with new score " + score);
            // Update the score in PlayerPrefs
            PlayerPrefs.SetInt(key, score);
        }
    }
}

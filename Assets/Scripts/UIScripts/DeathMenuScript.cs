using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/*
    DeathMenuScript.cs
    Author: Angus (Inherited from Julians UI scripts)
    Desc: Manage the Death Menu UI component. DisplayDeathScreen() will be shown when the player dies..
        A set of buttons will show allowing the player to restart or return to the main menu. 
*/
public class DeathMenuScript : MonoBehaviour

{
    public GameObject deathScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // This line makes sure the death screen is not visible when the scene is started
        deathScreen.SetActive(false);
    }

    // This is called externally. I've made it public so that it can be interfaced with by another script (when the player dies)
    public void DisplayDeathScreen()
    {
        // Sets the death screen as "active", basically showing it on the screen
        deathScreen.SetActive(true);
        // Set the time scale to 0, pausing the game
        Time.timeScale = 0f;
    }

    // This is for tthe restart button. This will set the level back to its initial state
    public void Restart()
    {
        // Make sure the time is resumed after restarting the game
        Time.timeScale = 1f;
        // This loads the current scene again, replacing the current instance of the level
        // This gives the illusion of a "restart"
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // This is for the main menu button. This will take the player back to the main menu scene
    public void GoToMainMenu()
    {
        // Make sure the time is resumed after leaving the game
        Time.timeScale = 1f;
        // This loads the main menu scene, which is at index 0 in the build settings
        SceneManager.LoadScene(0);
    }
}

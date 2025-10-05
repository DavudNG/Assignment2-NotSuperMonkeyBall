using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    //each method is used in a button to load its specific scene number.
    public void LoadSelectLevel(int sceneNumber)
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel1(int sceneNumber)
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel2(int sceneNumber)
    {
        SceneManager.LoadScene(3);
    }

    public void LoadLevel3(int sceneNumber)
    {
        SceneManager.LoadScene(4);
    }

    public void LoadSettings(int sceneNumber)
    {
        SceneManager.LoadScene(5);
    }

    public void LoadTitleScreen(int sceneNumber)
    {
        SceneManager.LoadScene(0);
    }

    public void reset()
    {
        // This method is used to reset all PlayerPrefs, including level progress and high scores
        // This is useful for testing purposes to ensure that the game behaves as expected from a fresh state
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("PlayerPrefs have been reset.");
        SceneManager.LoadScene(1);
    }

    public void toggleDyslexiaFont()
    {
        // Toggles the dyslexia-friendly font on and off
        int currentFont = PlayerPrefs.GetInt("DyslexiaFont", 0);

        // Switch the player preference for the font
        if (currentFont == 0)
        {
            PlayerPrefs.SetInt("DyslexiaFont", 1);
            Debug.Log("Dyslexia Font Enabled");
        }
        else
        {
            PlayerPrefs.SetInt("DyslexiaFont", 0);
            Debug.Log("Dyslexia Font Disabled");
        }

        // Reload the TMP assets in the scene by looking  through all FontSwitch scripts
        foreach (var text in FindObjectsOfType<FontSwitch>())
        {
            // Use the ApplyFont method to update the font based on the new setting
            text.ApplyFont();
        }
    }


}

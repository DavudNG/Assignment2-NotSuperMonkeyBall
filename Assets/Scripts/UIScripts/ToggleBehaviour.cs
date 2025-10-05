using UnityEngine;
using UnityEngine.UI;

public class ToggleBehavior : MonoBehaviour
{

    // A variable to store the toggle component we are targetting
    private Toggle toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // Get the Toggle component attached to this GameObject
        toggle = GetComponent<Toggle>();
    }

    void Start()
    {
        // Set the toggle display to match the current PlayerPrefs value
        updateToggleDisplay(); 
        
        // Debugging to check the current state of the PlayerPrefs value
        Debug.Log("DyslexiaFont Player Pref is read as: " + PlayerPrefs.GetInt("DyslexiaFont", 0));
    }

    void updateToggleDisplay()
    {

        // Get the current value from PlayerPrefs and set the toggle state accordingly
        if (PlayerPrefs.GetInt("DyslexiaFont", 0) == 1)
        {
            // Set the toggle to on if the font is enabled
            // This is dependant on the PlayerPrefs value being correctly set elsewhere in the application
            Debug.Log("Dyslexia font is read as enabled - toggle is toggled on");
            toggle.SetIsOnWithoutNotify(true);
        }
        else
        {
            // Set the toggle to off if the font is not enabled
            // This is dependant on the PlayerPrefs value being correctly set elsewhere in the application
            Debug.Log("Dyslexia font is read as disabled - toggle is toggled off");
            toggle.SetIsOnWithoutNotify(true);
        }
    }

    public void toggleDyslexiaFont()
    {
        // Toggles the dyslexia-friendly font on and off
        int currentFont = PlayerPrefs.GetInt("DyslexiaFont", 0);

        // Switch the player preference for the font
        if (currentFont == 0)
        {
            // Set the player pref to the opposite value of what it was read as 
            PlayerPrefs.SetInt("DyslexiaFont", 1);
            // Debugging to help track changes
            Debug.Log("Dyslexia Font Enabled by toggle");
        }
        else
        {
            // Set the player pref to the opposite value of what it was read as 
            PlayerPrefs.SetInt("DyslexiaFont", 0);
            // Debugging to help track changes
            Debug.Log("Dyslexia Font Disabled by toggle");
        }

        // Save the changes to prevent desynchronization
        PlayerPrefs.Save();

        // Get the scene manager script to change all fonts in the scene
        SceneManagerScript sceneManager = FindObjectOfType<SceneManagerScript>();

        // Null check to prevent errors if the scene manager is not found
        if (sceneManager != null)
        {
            // Change all fonts in the scene to match the new setting
            sceneManager.changeGlobalFonts();
        }
    }
}

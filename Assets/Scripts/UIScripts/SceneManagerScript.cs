using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    void Start()
    {

    }

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

    public void changeGlobalFonts()
    {
        // Reload the TMP assets in the scene by looking  through all FontSwitch scripts
        foreach (var text in FindObjectsOfType<FontSwitch>())
        {
            // Use the ApplyFont method to update the font based on the new setting
            text.ApplyFont();
        }
    }
}

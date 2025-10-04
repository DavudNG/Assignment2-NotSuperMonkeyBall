using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

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

    public void DisplayFinishLevelScreen()
    {
        finishLevelScreen.SetActive(true);
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
}

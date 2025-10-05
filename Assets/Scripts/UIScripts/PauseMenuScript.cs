using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    //sets pauseMenu as canvas overlay
    public GameObject pauseMenu;
    public static bool isPaused;

    void Start()
    {
        //turns off pause menu when game is started
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if Escape is pressed, game pauses. If already paused, unpauses game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    //turns off game time, which stops everything while game is paused.
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    //resumes game time, which allows everything to start up again
    public void ResumeGame()
    {
        Debug.Log("Resume Game");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    //button to allow user to return to main menu
    public void GoToMainMenu(int sceneNumber)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class DeathMenuScript : MonoBehaviour

{
    public GameObject deathScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        deathScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DisplayDeathScreen()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu(int sceneNumber)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

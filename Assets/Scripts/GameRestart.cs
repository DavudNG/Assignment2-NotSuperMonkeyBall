using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class GameRestart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Nothing needed here
    }

    // Update is called once per frame
    void Update()
    {
        // Continually check if the user has pressed the 'r' key
        // If the 'r' key is pressed, restart the current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

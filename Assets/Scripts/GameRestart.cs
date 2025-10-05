using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

/*
    GameRestart.cs
    Author: Angus
    Desc: This script is attached to the flag at the end of each level.
        It detects when the player collides with the flag and triggers the completion of the level
*/
public class GameRestart : MonoBehaviour
{

    // Update is called once per frame
    // We use update to monitor inputs
    void Update()
    {
        // Continually check if the user has pressed the 'r' key
        // If the 'r' key is pressed, restart the current scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            // We restart the level by replacing the current instance of the scene with an initialzed one
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

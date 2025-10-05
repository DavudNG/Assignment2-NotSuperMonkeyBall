using UnityEngine;

public class FinishFlag : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Don't need this
        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        // Don't need this
    }
    
    // Monitor when something enters the trigger area of the finish flag
    private void OnTriggerStay2D(Collider2D other)
    {
        // This line gets the other rigidbody2d component of the object that entered the trigger area
        Rigidbody2D rb = other.attachedRigidbody;

        // Need to check that the other object actually has a rigid body
        // If the rigid body comes from the Ball then the level is complete
        if (rb != null && other.CompareTag("Ball"))
        {
            // We need to read the players score at the time of collision
            int score = (int)FindObjectOfType<LevelTimerScript>().currentTime;
            FinishLevelScript finishLevel = FindObjectOfType<FinishLevelScript>();
            SoundManager.PlaySound(SoundType.WIN);
            Debug.Log("Level Complete! Score: " + score);
            finishLevel.DisplayFinishLevelScreen(score, UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }
    }
}

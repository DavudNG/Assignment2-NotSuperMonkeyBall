using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLvlScript : MonoBehaviour
{
    //script for goal post to move to next level.
    public int nextSceneLoad;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    //method that sends player to next level when goal post is touched
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //gets current level + current level timer and sets player prefs accordingly
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            int timeLeft = LevelTimerScript.instance != null ? LevelTimerScript.instance.GetRemainingTime() : 0;

            string key = "HighScore_Level" + levelIndex;
            int previousScore = PlayerPrefs.GetInt(key, 0);

            //if current run time is greater than previous attempt, updates highscore with new highscore
            if (timeLeft > previousScore)
            {
                PlayerPrefs.SetInt(key, timeLeft);
            }

            //changes player current level at by loading next scene
            if (nextSceneLoad > PlayerPrefs.GetInt("lvlAt"))
            {
                PlayerPrefs.SetInt("lvlAt", nextSceneLoad);
            }

            //loads next scene
            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}

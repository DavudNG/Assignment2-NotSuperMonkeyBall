using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLvlScript : MonoBehaviour
{
    public int nextSceneLoad;
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int levelIndex = SceneManager.GetActiveScene().buildIndex;
            int timeLeft = LevelTimerScript.instance != null ? LevelTimerScript.instance.GetRemainingTime() : 0;

            string key = "HighScore_Level" + levelIndex;
            int previousScore = PlayerPrefs.GetInt(key, 0);

            if (timeLeft > previousScore)
            {
                PlayerPrefs.SetInt(key, timeLeft);
            }

            if (nextSceneLoad > PlayerPrefs.GetInt("lvlAt"))
            {
                PlayerPrefs.SetInt("lvlAt", nextSceneLoad);
            }

            SceneManager.LoadScene(nextSceneLoad);
        }
    }
}

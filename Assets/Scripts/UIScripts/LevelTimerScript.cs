using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerScript : MonoBehaviour
{
    //sets level timer to 999 seconds.
    public float startTime = 999f;
    public float currentTime;
    public TextMeshProUGUI timerText;

    public static LevelTimerScript instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        //counts down from 999 using time.deltaTimer
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            currentTime = 0;
        }

        //sets timer overlay text to the correct time remaining.
        if (timerText != null)
        {
            timerText.text = Mathf.FloorToInt(currentTime).ToString();
        }
    }

    //method to get remaining time.
    public int GetRemainingTime()
    {
        return Mathf.FloorToInt(currentTime);
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimerScript : MonoBehaviour
{
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
        currentTime -= Time.deltaTime;
        if (currentTime < 0)
        {
            currentTime = 0;
        }

        if (timerText != null)
        {
            timerText.text = Mathf.FloorToInt(currentTime).ToString();
        }
    }

    public int GetRemainingTime()
    {
        return Mathf.FloorToInt(currentTime);
    }
}

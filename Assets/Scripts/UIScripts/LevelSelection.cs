using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    public Button[] lvlButtons;
    public TextMeshProUGUI[] scoreTexts;

    void Start()
    {
        int lvlAt = PlayerPrefs.GetInt("lvlAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            int levelIndex = i + 2;

            if (levelIndex > lvlAt)
            {
                lvlButtons[i].interactable = false;
            }

            string key = "HighScore_Level" + levelIndex;
            int highScore = PlayerPrefs.GetInt(key, 0);

            if (scoreTexts.Length > i && scoreTexts[i] != null)
            {
                scoreTexts[i].text = $"High Score: {highScore}";
            }
        }
    }
}

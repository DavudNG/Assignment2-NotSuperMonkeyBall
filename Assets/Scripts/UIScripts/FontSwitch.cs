using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FontSwitch : MonoBehaviour
{

    // This script is used to switch all UI text elements between a default and dyslexia-friendly font

    public TMP_FontAsset defaultFont;
    public TMP_FontAsset dyslexiaFont;

    private TextMeshProUGUI tmp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void ApplyFont()
    {
        // Check the player prefs to see if the dysliexia font is enabled
        if (PlayerPrefs.GetInt("DyslexiaFont", 0) == 1)
        {
            // Set to the dyslexia font
            tmp.font = dyslexiaFont;
        }
        else
        {
            // Set to the default font
            tmp.font = defaultFont;
        }
    }
}

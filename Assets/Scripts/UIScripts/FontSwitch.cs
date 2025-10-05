using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
/*
    FontSwitch.cs
    Author: Angus
    Desc: This script is attached to all TMP text elements in the UI.
        It checks the PlayerPrefs to see if the dyslexia font is enabled, and switches the font accordingly.
        This allows for a more accessible UI for players with dyslexia.
*/
public class FontSwitch : MonoBehaviour
{

    // Create references to the two fonts we will be switching between
    public TMP_FontAsset defaultFont;
    public TMP_FontAsset dyslexiaFont;

    // Create a reference to the TextMeshProUGUI component
    private TextMeshProUGUI tmp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // This is the component we will be editing
        tmp = this.GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        // Make sure the correct font is applied when the scene starts
        ApplyFont(); 
    }

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
            // If the dyslexia font is not enabled,
            // Set to the default font
            tmp.font = defaultFont;
        }
    }
}

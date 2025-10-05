using UnityEngine;
using UnityEngine.UI;

public class ColourblindMode
{
    public void ColourblindToggle()
    {
        if (!ReadWrite.CheckAttribute("isColourblind"))
        {
            ReadWrite.WriteAttribute("isColourblind", "true");
        }
        if (ReadWrite.CheckAttribute("isColourblind"))
        {
            ReadWrite.WriteAttribute("isColourblind", "false");
        }
    }
}

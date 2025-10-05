using UnityEngine;
using UnityEngine.UI;


/*
    Colourblind Mode.cs     
    Author: James

    Desc: This script changes the value of the "isColourblind" attribute in the textfile so the filter for it can be changed accordingly
*/
public class ColourblindMode
{
    public void ColourblindToggle() // Public function to be called by the onclick event of the button this script is attached to
    {
        if (!ReadWrite.CheckAttribute("isColourblind")) // Checks if the textfile attribute "isColourblind" is set to false, if so sets it to true
        {
            ReadWrite.WriteAttribute("isColourblind", "true"); // Sets the colourblind attribute to true
        }
        if (ReadWrite.CheckAttribute("isColourblind"))  // Checks if the textfile attribute "isColourblind" is set to false, if so sets it to true
        {
            ReadWrite.WriteAttribute("isColourblind", "false"); // Sets the colourblind attribute to false
        }
    }
}

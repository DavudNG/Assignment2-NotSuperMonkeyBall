using UnityEngine;

public class DeleteProgressScript : MonoBehaviour
{
    //method that resets all player prefs which resets the score system to 0. 
    //restarts game stats.
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
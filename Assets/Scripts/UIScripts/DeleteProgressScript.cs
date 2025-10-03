using UnityEngine;

public class DeleteProgressScript : MonoBehaviour
{
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    
}
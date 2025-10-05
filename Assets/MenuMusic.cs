using System.Collections;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool stopPlaying = false; // Bool to stop the execution of another soundtrack after one has already been started
    void Start()
    {
    }
    IEnumerator soundCoroutine() // Coroutine to stop the update method for 68 seconds
    {
        stopPlaying = true; // Set bool to true to indicate no other sounds should play
        yield return new WaitForSeconds(68f); // Wait 68 seconds
        stopPlaying = false; // Set bool to false to indicate another sound can play
    }

    // Update is called once per frame
    void Update() // Update method getting called constantly
    {
        if (!stopPlaying) // If no other music is playing then
        {
            SoundManager.PlaySound(SoundType.MENUMUSIC); // Play the menu music if it is not on cooldown
            StartCoroutine(soundCoroutine()); // Start the cooldown for the menu music to ensure only 1 plays at a time
        }
    }
}

using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

/*
    PlayerHealth.cs     
    Author: Angus 
    Co-Author: David(Hitflash functionality)
    Desc: This script handles player hp and makes the player flash on being damaged
*/
public class PlayerHealth : MonoBehaviour
{
    // Initialize the players health at 3
    public int health = 3;

    // Hitflash variables
    public SpriteRenderer myRenderer; // Ref to the renderer of the player
    private Coroutine _hitFlashCorotine; // Ref to the coroutine 
    private Color origColor; // To store the original color of the player
    public float flashTime; // Float that denotes the duration of the flash

    
    void Start() {
        origColor = myRenderer.color; // grab the original colour from the renderer
    }

    //  We don't need anything here
    void update() {

    }

    // The spikes or enemies will call this function when they collide with the player
    // We keep all the values of the player private, we only allow this interface for other objects to administer damage
    public void takeDamage() {

        // If the player has more than  0 health administer damage
        if (health-1 >= 1)
        {
            SoundManager.PlaySound(SoundType.HURT);
            health -= 1;
            Debug.Log("Player Health: " + health);
            CallHitFlash(); // call hitflash coroutine
        }
        else
        {
            // The player died
            // Some useful logging statements
            Debug.Log("Player dead!");
            // Play a sound indicating the player death
            SoundManager.PlaySound(SoundType.DEATH);
            // Find the death screen 
            DeathMenuScript deathMenu = FindObjectOfType<DeathMenuScript>();
            // Display the death screen
            deathMenu.DisplayDeathScreen();
        }
    }

    /*
        CallHitFlash() 
        Author: David
        Desc: Calls the hitFlasher coroutine on demand
    */
    public void CallHitFlash() 
    {
        _hitFlashCorotine = StartCoroutine(HitFlasher()); // starts the coroutine and sets the reference to it
    }

    /*
        HitFlasher() 
        Author: David
        Desc: IEnumerator that lerps(linear interpolation: smooth transition between 2 points) 
        the renderer's colour values for a duration of time equal to flashtime
    */
    private IEnumerator HitFlasher()
    {
        float elapsedTime = 0f; // float to hold the current elapsed time

        while (elapsedTime < flashTime) // while the elapsed time doesnt exceed the flashtime
        {
            elapsedTime += Time.deltaTime; // increment the elapsed time

            Color lerpedColor = Color.Lerp(Color.red, origColor, elapsedTime / flashTime); // lerp the colour value from the intended colour back to the original color  
            myRenderer.color = lerpedColor; // set the renderer's color each time to transition the color for the hit effect 
            yield return null; // pause the coroutine for a single frame 
        }
    }
}

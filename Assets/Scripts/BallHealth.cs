using UnityEngine;

/*
    PlayerHealth.cs     
    Author: Angus 
    Desc: This script handles ball hp
*/
public class BallHealth : MonoBehaviour
{
    // Initialize the ball health at 3
    // Can be overwritten in the inspector
    public int health = 3;

    // The spikes or enemies will call this function when they collide with the player
    // We keep all the values of the player private, we only allow this interface for other objects to administer damage
    public void takeDamage()
    {
        // If the ball has more than 0 health administer damage
        if (health - 1 >= 1)
        {
            // Minus one from the balls health
            health -= 1;
            // Some useful logging statements
            Debug.Log("Player Health: " + health);
        }
        else
        {
            // If the ball has 0 or less health, it is dead
            Debug.Log("Ball dead!");
            // Locate the death menu UI elements - this is deprecated but it works for now
            DeathMenuScript deathMenu = FindObjectOfType<DeathMenuScript>();
            // Call the death menu script to display the death screen
            deathMenu.DisplayDeathScreen();
        }
    }
}

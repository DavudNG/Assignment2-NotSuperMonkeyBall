using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Initialize the players health at 3
    public int health = 3;

    // We don't need anything here
    void Start() {

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
        }
        else
        {
            Debug.Log("Player dead!");
            SoundManager.PlaySound(SoundType.DEATH);
            DeathMenuScript deathMenu = FindObjectOfType<DeathMenuScript>();
            deathMenu.DisplayDeathScreen();
        }
    }
}

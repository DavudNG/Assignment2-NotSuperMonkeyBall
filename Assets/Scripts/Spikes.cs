using UnityEngine;
using System.Collections;

/*
    Spikes.cs
    Author: Angus
    Desc: This script is attached to the spikes on the level.
        This script essentially allows the player to get damaged when touching a spike
        Spikes have a unique hitbox that is a trigger, so we can use OnTriggerEnter2D and OnTriggerExit2D
    Issue: As the spikes hitboxes are triggers, this code is constantly run while the player is in the hitbox
        Unfortunately, this means that if the player enters the hitbox at a lower point they may get damaged multiple times
        before leaving the hitbox. To alleviate this, a cooldown has been applied to this script so that the 
        player can only get damaged once every 0.5 seconds while touching the spikes.
        This now means that if tthe ball touches the spikes slighly before the player does, the spikes will lag
        and the player will not be damaged until re-entering the hitbox.

*/
public class Spikes : MonoBehaviour
{

    // Is the player getting damaged right now?
    private bool isDamaging = false;

    // Check for any collisions with a rigidbody2d
    private void OnTriggerStay2D(Collider2D other)
    {

        // When the player enters the trigger zone we need to initiate damage
        // However.. We can't just continuously damage the player every frame while they are touching the spikes
        // So we will use a coroutine to handle the timing of the damage
        // When the player is taking damage we will flag it

        if (isDamaging) return;

        // Initialize a coroutine to handle damage timing if needed
        StartCoroutine(takeDamage(other));

    }

    IEnumerator takeDamage(Collider2D other)
    {
        // Flag that we are damaging the player
        isDamaging = true;

        // Trigger the object to take damage
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            // Call your takeDamage() function
            player.takeDamage();
        }

        // Launch the player up like a spring
        // This code is copied from Spring.cs

        GameObject playerObject = other.gameObject;

        // Example: apply a force if it has a Rigidbody2D
        Rigidbody2D rb = playerObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
        }

        // Wait for 0.5 seconds before allowing damage again
        // This is to prevent the player from taking damage every frame while touching the spikes
        yield return new WaitForSeconds(0.5f);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // When the player leaves the trigger zone we can stop damaging them
        isDamaging = false;
    }
}

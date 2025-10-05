using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Spring.cs
    Author: Angus
    Desc: This script is attached to the spring prefab, launching the player in tthe air upon collision
        Similarly to the spikes, a cooldown is applied to prevent multiple launches while touching the spring
        in order to prevent excessive launching
*/
public class Spring : MonoBehaviour
{
    private bool isJumping = false;

    // This function is called when another collider makes contact with this object's collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This is the object that touched the spring
        GameObject otherObject = collision.gameObject;

        // Apply a force if it has a Rigidbody2D and not already jumping
        Rigidbody2D rb = otherObject.GetComponent<Rigidbody2D>();
        if (rb != null && !isJumping)
        {
            // Use a coroutine to allow a cooldown
            StartCoroutine(jump(rb));
        }
    }

    IEnumerator jump(Rigidbody2D rb)
    {
        // Initiate a jump
        isJumping = true;

        // Apply an upwards force
        rb.AddForce(Vector2.up * 15f, ForceMode2D.Impulse);

        // Cooldown so force isn't applied every frame the object is touching the spring
        yield return new WaitForSeconds(0.5f);

        // Jump finished
        isJumping = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // When the player leaves the trigger zone we can stop jumping
        isJumping = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{

    // Make sure the player doesn't get laaunched multiple times while touching the spring
    private bool isJumping = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This is the object that touched the spring
        GameObject otherObject = collision.gameObject;

        Debug.Log("Spring interacted with by: " + otherObject.name);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    Powerup.cs
    Author: James
    Desc: This script can be attached to an object to increase the player's jump height if the player collides with the object the script is attached to.
*/
public class Powerup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // When an object collides with the object this script is attached to
    {
        if (gameObject.GetComponent<PlayerMovement>()) { // If the object colliding has the player movement component (is a player)
            PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>(); // Get the player movement component

            if (pm != null) // If the player movement component exists
            {
                pm.jumpForce = 10f;   // Increase the player's jump height
            }

            Destroy(gameObject); // Destroy the object so it cannot be obtained again
        }
    }
}

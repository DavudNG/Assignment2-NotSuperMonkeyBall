using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
    DamagePlayer.cs     
    Author: James
    
    Desc: This script can be attached to an object to hurt the player on collision with said object and the player, using the method in Health.cs
*/

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
 private void OnCollisionEnter2D(Collision2D collision) // When the object this script is attached to collides with the player
    {
        // Check if we hit the player
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if (playerHealth != null) // If the health exists
        {
            playerHealth.ApplyDamage(); // call the player's ApplyDamage method
        }
    }
}
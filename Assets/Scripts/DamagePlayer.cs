using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    // Start is called before the first frame update
 private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit the player
        Health playerHealth = collision.gameObject.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.ApplyDamage(); // call the player's ApplyDamage method
        }
    }
}
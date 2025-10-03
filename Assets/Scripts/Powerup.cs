using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.GetComponent<PlayerMovement>()) {
            PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();

            if (pm != null)
            {
                pm.jumpForce = 10f;   // now the player jumps higher
                Debug.Log("Player jumpForce increased!");
            }

            Destroy(gameObject);
        }
    }
}

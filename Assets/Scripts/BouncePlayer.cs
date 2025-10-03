using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class BouncePlayer : MonoBehaviour
{
    [SerializeField] public float bounceHeight;
    private bool i = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D playerRigidbody = collision.rigidbody;
        if (playerRigidbody != null)
        {
            Vector2 playerVelocity = playerRigidbody.linearVelocity;
            playerRigidbody.linearVelocity = new Vector2(playerVelocity.x, bounceHeight);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildEnemy : ParentEnemy
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Explode(-collision.rigidbody.velocity.normalized * 10, 1.5f);
            }
        }
    }
}

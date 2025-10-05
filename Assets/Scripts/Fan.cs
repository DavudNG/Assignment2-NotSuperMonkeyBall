using UnityEngine;

/*
    Fan.cs
    Author: Angus
    Desc: This script is attached to the fan objects in the level.
        It applies a continuous force to any rigidbody2D that enters its trigger area.
        This can be used to simulate wind or air movement in the game.
*/
public class Fan : MonoBehaviour
{
    // The force of the fan - how much the object will be pushed by
    public float fanForce = 10f;

    // This is the direction that the fan will blow towards
    public Vector2 fanDirection = new Vector2(1, 0);

    // This function is called once per frame for every collider that is touching the trigger area
    // We use OnTriggerStay2D because we want to apply a continuous force while the object is in the fan area
    private void OnTriggerStay2D(Collider2D other)
    {
        // This line gets the other rigidbody2d component of the object that entered the trigger area
        Rigidbody2D rb = other.attachedRigidbody;

        // Need to check that the other object actually has a rigid body
        if (rb != null)
        {
            // Add the force to the rigid body in the direction of the fan
            rb.AddForce(fanDirection.normalized * fanForce);
        }
    }

}


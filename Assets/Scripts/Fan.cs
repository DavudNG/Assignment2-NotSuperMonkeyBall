using UnityEngine;

public class Fan : MonoBehaviour
{
    // The force of the fan - how much the object will be pushed by
    public float fanForce = 10f;

    // This is the direction that the fan will blow towards
    public Vector2 fanDirection = new Vector2(1, 0);

    // This function is called when a collider enters the trigger area of the fan's box collider 2d
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


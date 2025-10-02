using UnityEngine;

public class WindForce : MonoBehaviour
{
    // Set the direction for the force, the value (-1, 0) means to the left
    public Vector2 forceDirection = new Vector2(-1, 0);

    // This is the value dictating the strenght of the force
    // 8 seems to be the best value from testing
    public float forceStrength = 8f;

    // Reference to the Rigidbody2D component of the object which the script is attached to
    Rigidbody2D rb;

    // Runs when the object is initialized
    void Start()
    {
        // Get the Rigidbody2D component of the object
        rb = GetComponent<Rigidbody2D>();

        // If the object has no rigid body, log an error
        if(rb == null)
            Debug.LogError("No Rigidbody2D found on this object!");
    }

    // Runs every frame
    void FixedUpdate()
    {
        // Apply the force to the object's rigid body
        rb.AddForce(forceDirection * forceStrength);
    }
}

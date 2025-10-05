using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

/*
    ParentEnemy.cs
    Author: James
    Desc: This script provides majority of the code for the enemies, with enemy movement outlined, but allows the child enemy classes to build on it to differenciate them.
*/

public class ParentEnemy : MonoBehaviour
{
    public enum MovementType { backNForth, followPlayer }; // Declares 2 movement types for the enemies
    [SerializeField] private MovementType movementType; // Allows to select a particular movement type for the enemy this script is attached to
    [SerializeField] private float BNF_speed; // Speed of the enemy's movement
    [SerializeField] private float BNF_time; // Time between movements for the "BackAndForth" movement type
    private bool colliding; // Bool to check if a collision is occurring
    public Transform player; // Transform for the player's position for the "FollowPlayer" movement type

    private Rigidbody2D body; // Enemy's Rigidbody2D to control their movement using vectors

    void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Gets the Rigidbody2D of the object this script is attached to

        if (movementType == MovementType.backNForth) // If the movement type selected is back and forth
        {
            StartCoroutine(BackAndForth()); // Start the associated back and forth coroutine, which the enemy will forever do
        }
        else if (movementType == MovementType.followPlayer) // If the movement type is follow player
        {
            StartCoroutine(FollowPlayer()); // Start the associated follow player coroutine, which the enemy will forever do
        }
    }
    private IEnumerator FollowPlayer() // IEnumerator for the follow player coroutine
    {
        while (true) // Infinite loop
        {
            Vector3 direction = player.position - transform.position; // Get a vector going towards the player's position from the enemy's position
            body.linearVelocity = new Vector2(direction.x, 0); // Move in the direction of the player
            yield return new WaitForSeconds(0.1f); // Wait for 0.1 seconds to avoid crashing
        }
    }

    private IEnumerator BackAndForth() // IEnumerator for the back and forth coroutine
    {
        while (true) // Infinite loop
        {
            body.linearVelocity = new Vector2(-BNF_speed, body.linearVelocity.y); // Move to the left
            yield return new WaitForSeconds(BNF_time); // Wait for the selected time
            body.linearVelocity = new Vector2(BNF_speed, body.linearVelocity.y); // Move to the right
            yield return new WaitForSeconds(BNF_time); // Wait for the selected
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // This is the object that touched this one
        GameObject otherObject = collision.gameObject;

        // You can do whatever you want with it
        Debug.Log("Touched by: " + otherObject.name);

        // Example: apply a force if it has a Rigidbody2D
        Rigidbody2D rb = otherObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(Vector2.up * 20f, ForceMode2D.Impulse);
        }
    }
}

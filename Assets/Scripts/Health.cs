using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
    Health.cs     
    Author: James

    Desc: This script changes the player's health according to a method that can be called by another object hurting the player
*/
public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("Health is now: " + health.ToString());
    }

    public void ApplyDamage()
    {
        health--; // Decrease health when method is called from another object hurting the player
        Debug.Log("Health is now: " + health.ToString());
    }
}

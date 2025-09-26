using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        health--;
        Debug.Log("Health is now: " + health.ToString());
    }
}

using UnityEngine;

/*
FPSCap.cs     
Author: David

This script forces the game to run at 120 fps 
*/
public class FPSCap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 120; // should refactor this to use player preferences
    }
}

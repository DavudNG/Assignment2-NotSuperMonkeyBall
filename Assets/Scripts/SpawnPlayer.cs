using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
    SpawnPlayer.cs
    Author: James
    Desc: This script primarily manages the spawning and teleportation of enemies, contrary to its name.
*/
public class SpawnPlayer : MonoBehaviour
{
    public static SpawnPlayer instance { get; private set; } // Variable to store this
    [SerializeField] private GameObject[] spawnObjects; // Array to store all the objects to be manipulated by this script
    private Vector3 spawnLocation; // Vector3 to store a location to teleport/spawn to
    private Vector3 storeInitialLocation; // Vector3 to store the initial location of the object this script is attached to

    // These arrays stores the locations of where all the enemies should spawn
    private Vector3[] level1Locations = {
    new Vector3(40f, -3.5f, 0f),
    new Vector3(86f, 0f, 0f),
    new Vector3(97f, 0f, 0f),
    new Vector3(109f, 0f, 0f)
    };
    private Vector3[] level2Locations = {
    new Vector3(100f, 4f, 0f)
    };
    private Vector3[] level3Locations = {
    new Vector3(43f, 1f, 0f)
    };
    private bool stopPlaying = false; // Variable to store the cooldown time between sounds

    void Awake() // When in use
    {
        instance = this; // Store this
    }

    void Start() // On start
    {
        spawnLocation = transform.position; // Store the initial location of the object this script is attached to
        storeInitialLocation = spawnLocation; // Store the initial location of the object this script is attached to to a variable that will not change after this
        spawnEach(); // Teleport the enemies to their predetermined locations as defined in the arrays
    }
    // This function is called when a collider enters the trigger area of the fan's box collider 2d
    
    IEnumerator level1Coroutine() // Coroutine to ensure only 1 level 1 soundtrack plays at a time
    {
        stopPlaying = true; // While this cooldown is active, do not play another soundtrack
        yield return new WaitForSeconds(135f); // No other soundtrack can be played for the duration of the currently playing soundtrack
        stopPlaying = false; // Another soundtrack can be played now
    }
    
    IEnumerator level2Coroutine() // Coroutine to ensure only 1 level 2 soundtrack plays at a time
    {
        stopPlaying = true; // While this cooldown is active, do not play another soundtrack
        yield return new WaitForSeconds(236f); // No other soundtrack can be played for the duration of the currently playing soundtrack
        stopPlaying = false; // Another soundtrack can be played now
    }
    
    IEnumerator level3Coroutine() // Coroutine to ensure only 1 level 3 soundtrack plays at a time
    {
        stopPlaying = true; // While this cooldown is active, do not play another soundtrack
        yield return new WaitForSeconds(220f); // No other soundtrack can be played for the duration of the currently playing soundtrack
        stopPlaying = false; // Another soundtrack can be played now
    }

    void Update() // Constantly called
    {
        if (SceneManager.GetActiveScene().name == "Level1" && !stopPlaying) // If level 1 is started and no soundtrack is currently playing, play the soundtrack
        {
            SoundManager.PlaySound(SoundType.LEVEL1MUSIC, 0.1f); // Play the soundtrack at 10% volume
            StartCoroutine(level1Coroutine()); // Start the level 1 song cooldown to ensure only 1 instance of the soundtrack plays at a time
        }
        if (SceneManager.GetActiveScene().name == "Level2" && !stopPlaying) // If level 2 is started and no soundtrack is currently playing, play the soundtrack
        {
            SoundManager.PlaySound(SoundType.LEVEL2MUSIC, 0.1f); // Play the soundtrack at 10% volume
            StartCoroutine(level2Coroutine()); // Start the level 2 song cooldown to ensure only 1 instance of the soundtrack plays at a time
        }
        if (SceneManager.GetActiveScene().name == "Level3" && !stopPlaying) // If level 3 is started and no soundtrack is currently playing, play the soundtrack
        {
            SoundManager.PlaySound(SoundType.LEVEL3MUSIC, 0.1f); // Play the soundtrack at 10% volume
            StartCoroutine(level3Coroutine()); // Start the level 3 song cooldown to ensure only 1 instance of the soundtrack plays at a time
        }
    }

    void spawnEach() // Teleports the enemies in each level to their locations as defined in the arrays
    {
        // Gets the current scene, then loops through the associated location array for the scene
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            if (level1Locations.Length == spawnObjects.Length)
            {
                for (int i = 0; i < level1Locations.Length; i++)
                {
                    // The index within this for loop denotes the current enemy in the spawnObjects array
                    // It sets the spawn location for each enemy, spawning them in said location afterwards
                    SetSpawn(level1Locations[i]);
                    Spawn(i);
                }
            }
        }
        // Gets the current scene, then loops through the associated location array for the scene
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (level2Locations.Length == spawnObjects.Length)
            {
                for (int i = 0; i < level2Locations.Length; i++)
                {
                    // The index within this for loop denotes the current enemy in the spawnObjects array
                    // It sets the spawn location for each enemy, spawning them in said location afterwards
                    SetSpawn(level2Locations[i]);
                    Spawn(i);
                }
            }
        }
        // Gets the current scene, then loops through the associated location array for the scene
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (level3Locations.Length == spawnObjects.Length)
            {
                for (int i = 0; i < level3Locations.Length; i++)
                {
                    // The index within this for loop denotes the current enemy in the spawnObjects array
                    // It sets the spawn location for each enemy, spawning them in said location afterwards
                    SetSpawn(level3Locations[i]);
                    Spawn(i);
                }
            }
        }
    }

    public void SetSpawn(Vector3 location) // Set the spawnLocation variable to what is specified in the parameter
    {
        spawnLocation = location; // Set the spawnLocation variable to what is specified in the parameter
    }

    public void Reset(int index) // Reset the location of an enemy found at the index from the parameter in the enemy array
    {
        SetSpawn(storeInitialLocation); // Reset the location of the enemy back to its initial spawn location
        Spawn(index); // Teleport enemy
    }

    public void Spawn(int index) // Teleports the enemy found at the index from the parameter in the enemy array
    {
        spawnObjects[index].transform.position = spawnLocation; // Teleports the enemy to a location defined by spawnLocation
    }
}
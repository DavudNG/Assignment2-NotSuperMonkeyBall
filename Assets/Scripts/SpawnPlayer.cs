using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer : MonoBehaviour
{
    public static SpawnPlayer instance { get; private set; }
    [SerializeField] private GameObject[] spawnObjects;
    private Vector3 spawnLocation;
    private Vector3 storeInitialLocation;

    // These arrays stores the locations of where all the enemies should spawn
    private Vector3[] level1Locations = {
    new Vector3(40f, -3.5f, 0f),
    new Vector3(86f, 0f, 0f),
    new Vector3(97f, 0f, 0f),
    new Vector3(109f, 0f, 0f)
    };
    private Vector3[] level2Locations = {
    new Vector3(40f, -3.5f, 0f),
    new Vector3(40f, -3.5f, 0f),
    new Vector3(40f, -3.5f, 0f),
    new Vector3(40f, -3.5f, 0f)
    };
    private Vector3[] level3Locations = {
    new Vector3(40f, -3.5f, 0f),
    new Vector3(40f, -3.5f, 0f),
    new Vector3(40f, -3.5f, 0f),
    new Vector3(40f, -3.5f, 0f)
    };

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        spawnLocation = transform.position;
        storeInitialLocation = spawnLocation;
        spawnEach();
    }

    void spawnEach()
    {
        // Gets the current scene, then loops through the associated location array for the scene
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            Debug.Log("it got here");
            if (level1Locations.Length == spawnObjects.Length)
            {
                Debug.Log("it got here2");
                for (int i = 0; i < level1Locations.Length; i++)
                {
                    // The index within this for loop denotes the current enemy in the spawnObjects array
                    // It sets the spawn location for each enemy, spawning them in said location afterwards
                    Debug.Log("it got here3");
                    SetSpawn(level1Locations[i]);
                    Spawn(i);
                }
            }
        }
    }

    public void SetSpawn(Vector3 location)
    {
        spawnLocation = location;
    }

    public void Reset(int index)
    {
        SetSpawn(storeInitialLocation);
        Spawn(index);
    }

    public void Spawn(int index)
    {
        spawnObjects[index].transform.position = spawnLocation;
    }
}
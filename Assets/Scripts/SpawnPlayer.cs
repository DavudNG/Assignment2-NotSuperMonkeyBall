using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    public static SpawnPlayer instance { get; private set; }
    [SerializeField] private GameObject player;
    private Vector3 spawnLocation;
    private Vector3 storeInitialLocation;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        spawnLocation = transform.position;
        storeInitialLocation = spawnLocation;
        Spawn();
    }

    public void SetSpawn(Vector2 location)
    {
        spawnLocation = location;
    }

    public void Reset()
    {
        SetSpawn(storeInitialLocation);
        Spawn();
    }

    public void Spawn()
    {
        player.transform.position = spawnLocation;
    }
}


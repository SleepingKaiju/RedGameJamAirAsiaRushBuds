using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnObject : MonoBehaviour

{
    public GameObject[] prefabs; // Array of prefabs to spawn
    public Transform[] spawnPoints; // Array of spawn points
    public Transform parentTransform; // Parent transform to make spawned objects children

    public float spawnInterval = 2.0f; // Time interval between spawns


    void Start()
    {


        // Spawn objects at the start
        SpawnInitialObjects();
    }

    void Update()
    {

    }

    void SpawnInitialObjects()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            // Select a random prefab
            int prefabIndex = Random.Range(0, prefabs.Length);
            GameObject prefabToSpawn = prefabs[prefabIndex];

            // Instantiate the prefab at the current spawn point and set it as a child of the parentTransform
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation, parentTransform);
        }
    }

}


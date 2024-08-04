using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskBigie : MonoBehaviour
{

    public Transform[] spawnPoints;


    public GameObject[] objectsToSpawn;




    void Start()
    {

        if (spawnPoints.Length < 5 || objectsToSpawn.Length < 5)
        {
            Debug.LogError("There must be at least 5 spawn points and 5 objects to spawn.");
            return;
        }


        Shuffle(objectsToSpawn);


        for (int i = 0; i < 5; i++)
        {
            Instantiate(objectsToSpawn[i], spawnPoints[i].position, spawnPoints[i].rotation);
        }


    }



    // Function to shuffle an array
    void Shuffle(GameObject[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            GameObject temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }



}

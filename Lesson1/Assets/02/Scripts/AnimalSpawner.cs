using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
   
    public GameObject[] prefabAnimal;
    public float xSpawnRange;
    public float zSpawnPoint;
    public float spawnInterval;

    void Start()
    {
        InvokeRepeating("AnimalSpawner");  
    }

    private void AnimalSpawner()
    {
        if (Input.GetKey(KeyCode.K))
        {
            int animalIndex = Random.Range(0, prefabAnimal.Length);
            Vector3 animalPosition = new Vector3(
                Random.Range(-xSpawnRange, xSpawnRange),
                    0f,
                    zSpawnPoint
                );
            Instantiate(prefabAnimal[animalIndex], animalPosition, prefabAnimal[animalIndex].transform.rotation);
        }
    }
}

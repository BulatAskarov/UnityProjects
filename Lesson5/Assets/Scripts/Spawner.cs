using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRange = 5f;
    public float y = 0.52f;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Keypad9) ||
            Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Keypad6) || 
            Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            Vector3 position = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                y,
                Random.Range(-spawnRange, spawnRange)
            );
            Instantiate(prefab, position, prefab.transform.rotation);
        }
    }
    
  
}

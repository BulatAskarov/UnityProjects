using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{


    [SerializeField] private GameObject enemy;
    
    private float nextSpawnTime = 0.0f;
    [SerializeField]private float period = 5f;
    [SerializeField]private float difficultyPeriod = 10f;
    private float nextDifficulty = 10f;

    private int yRange1 = 0;
    private int yRange2 = 8;
    private int xRange1 = -7;
    private int xRange2 = 8;
    private int zRange1 = -7;
    private int zRange2 = 8;

    private float speed = 4;

    private GameObject startPoint;

    private float pauseTime = 1f;
    private float pausePoint = 0f;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        if (startPoint != null)
        {
            if ((Time.time - pauseTime) > nextDifficulty)
            {
                nextDifficulty += difficultyPeriod;
                if (period > 0.5f)
                {
                    period -= 0.5f;
                }
                
            }

            if ((Time.time - pauseTime) > nextSpawnTime)
            {
                nextSpawnTime += period;
                Instantiate(enemy, PositionRandomizerForward(), Quaternion.identity);
            }
        }
        else
        {
            pauseTime += Time.time - pausePoint;
        }

        pausePoint = Time.time;
        startPoint = null;
        
        
    }

    Vector3 PositionRandomizer360()
    {
        int plane = Random.Range(1, 4);

        int xz = Random.Range(1, 3);

        if (xz == 1) xz = xRange1;
        else xz = xRange2 - 1; 

        Vector3 pos = new Vector3();

        switch (plane)
        {
            case 2: 
                pos.x = Random.Range(xRange1, xRange2);
                pos.z = Random.Range(zRange1, zRange2);
                pos.y = yRange2 - 1;
                break;
            case 1:
                pos.x = xz;
                pos.y = Random.Range(yRange1, yRange2);
                pos.z = Random.Range(zRange1, zRange2);
                break;
            case 3:
                pos.x = Random.Range(xRange1, yRange2);
                pos.y = Random.Range(yRange1, yRange2);
                pos.z = xz;
                break;
        }
        return pos;
    }

    Vector3 PositionRandomizerForward()
    {
        Vector3 pos = new Vector3(Random.Range(-10, 11), Random.Range(0, 11), 15);
        
        return pos;
    }
    
}

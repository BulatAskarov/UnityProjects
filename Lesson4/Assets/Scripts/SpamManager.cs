using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class SpamManager : MonoBehaviour
{
    public GameObject[] obstacles;
    public Vector3 spawnPosition = new Vector3(25f, 0f,0f);
    public float repeatRate;
    public float startDelay;
    private int _myTime = 0;
    private int _repeat = 0;
    // Start is called before the first frame update
    void Start()
    {
//        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        _myTime += 1;
        if (_myTime == _repeat)
        {
            SpawnObstacle();
            _myTime = 0;
            _repeat = Random.Range(2, 4);
        }
    }

    private void SpawnObstacle()
    {
        int l = obstacles.Length;
        int i = Random.Range(0, l);
        var newGo = Instantiate(obstacles[i], spawnPosition, obstacles[i].transform.rotation);
    }
}

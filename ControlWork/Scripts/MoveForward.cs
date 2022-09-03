using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 5f;
    public float topBound = 5f;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        if (transform.position.x < -topBound)
        {
            Destroy(gameObject);
        }
    }
}

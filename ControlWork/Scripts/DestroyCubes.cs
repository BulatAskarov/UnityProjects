using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCubes : MonoBehaviour
{
    void Update()
    {
    }

    void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.name == "RedCube")
            {
                Destroy(col.gameObject);
                Destroy(gameObject);
            }
        }
    
}

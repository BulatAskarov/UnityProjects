using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet: MonoBehaviour
{
    [SerializeField]private float speed = 1;
    private float destroyTime = 4f;
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        destroyTime -= Time.deltaTime;
        if(destroyTime < 0) Destroy(gameObject);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);      
    }
    private void OnCollisionEnter(Collision col)
    {
        String name = col.gameObject.transform.tag;
        if (name.Equals("Enemy"))
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }     
    }
}

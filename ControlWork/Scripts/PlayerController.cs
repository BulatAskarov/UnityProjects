using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float zBorder = 10f;
    public GameObject bullet;
    public CharacterController controller;
    public float speed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            controller.Move(Time.deltaTime * speed * Vector3.right);
        }
        if (Input.GetKey(KeyCode.D))
        {
            controller.Move(Time.deltaTime * speed * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(Time.deltaTime * speed * Vector3.left);
        }
        if (Input.GetKey(KeyCode.A))
        {
            controller.Move(Time.deltaTime * speed * Vector3.back);
        }
       
        if (transform.position.z < -zBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBorder);
        }

        if (transform.position.z > zBorder)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBorder);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }
}
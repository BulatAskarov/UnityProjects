using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace _02.Scripts
{

    public class PlayerController : MonoBehaviour
    {
       
        public float speed = 30f;
        public float xBorder = 10f;
        public GameObject food;
        public GameObject prefabAnimal;
        public Vector3 spawnPoint;
        
        void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

            if (transform.position.x < -xBorder)
            {
                transform.position = new Vector3(-xBorder, transform.position.y, transform.position.z);
            }
            if (transform.position.x > xBorder)
            {
                transform.position = new Vector3(xBorder, transform.position.y, transform.position.z);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(food, transform.position, food.transform.rotation);
            }

            if (Input.GetKey(KeyCode.K))
            {
                Instantiate(prefabAnimal, spawnPoint, prefabAnimal.transform.rotation);
            }
        }
    }
}
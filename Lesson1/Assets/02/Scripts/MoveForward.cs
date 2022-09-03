using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _02.Scripts02
{
    public class MoveForward : MonoBehaviour
    {
        public float speed = 20f;
        void Update()
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
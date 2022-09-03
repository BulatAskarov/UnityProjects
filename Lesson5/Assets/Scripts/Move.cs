using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float cell = 2f;

    public float cell1 = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            transform.Translate(Vector3.forward * cell * cell1);
            transform.Translate(Vector3.right * cell);
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            transform.Translate(Vector3.forward * cell * cell1);
            transform.Translate(Vector3.left * cell);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            transform.Translate(Vector3.left * cell);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            transform.Translate(Vector3.right * cell);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            transform.Translate(Vector3.back * cell * cell1);
            transform.Translate(Vector3.right * cell);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            transform.Translate(Vector3.back * cell * cell1);
            transform.Translate(Vector3.left * cell);
        }
    }
}

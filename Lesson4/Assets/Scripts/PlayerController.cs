using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody myRigidbody;
    public float gravityModifyer;
    public float jumpForce;
    private bool isOnGround;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifyer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            myRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        isOnGround = true;
    }
}

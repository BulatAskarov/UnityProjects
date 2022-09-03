using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    private GameObject player;
    private Vector3 playerPos;

    private GameObject startPoint;

    [SerializeField] private AudioSource audio;

    [SerializeField] private float speed = 1f;
    
    
    
    

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        playerPos = player.transform.position;
        gameObject.transform.LookAt(playerPos);
        if (startPoint != null)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
        }
        else
        {
            audio.Play();
        }
        startPoint = null;
    }
}

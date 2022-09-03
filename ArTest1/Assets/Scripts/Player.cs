using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private GameObject endPoint;
    [SerializeField] private GameObject startPoint;
    [SerializeField] private GameObject retButton;
    [SerializeField] private GameObject menuButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnCollisionEnter(Collision col)
    {
        String name = col.gameObject.transform.tag;
        if (name.Equals("Enemy"))
        {
            endPoint.SetActive(true);
            retButton.SetActive(true);
            menuButton.SetActive(true);
            Destroy(startPoint);
            Debug.Log("Game Over");
        }     
        Debug.Log(name);
    }
}

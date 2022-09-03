using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class CubeEnemy : MonoBehaviour
{
    
    [SerializeField] private float plus = 0.001f;
    private Vector3 scale;
    [SerializeField] private float maxScale = 1f;
    
    [SerializeField] private GameObject endPoint;
    private bool endFlag = true;

    // Start is called before the first frame update
    void Start()
    {        
        scale = new Vector3(0.001f,0.001f, 0.001f);
        gameObject.transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        scale = gameObject.transform.localScale;
        if (scale.x > maxScale && endFlag)
        {
            Instantiate(endPoint);
            endFlag = false;
        }
        gameObject.transform.localScale= new Vector3(scale.x + plus * Time.deltaTime, scale.y + plus * Time.deltaTime, 0.001f);
    }
}

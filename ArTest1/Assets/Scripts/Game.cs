using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



public class Game : MonoBehaviour
{


    [SerializeField] private Camera arCamera;
    [SerializeField] private GameObject bullet;

    
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject endText;
     
    
    private float maxEnemies = 0;
    private GameObject[] enemies;
    private int score = 0;
    
    private GameObject endPoint;
    private bool endFlag = true;
     void Update()
    {   
        endPoint = GameObject.FindGameObjectWithTag("EndPoint");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length < maxEnemies)
        {
            score += 10;
            scoreText.text = score.ToString();
            maxEnemies = enemies.Length;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Instantiate(bullet, arCamera.transform.position, arCamera.transform.rotation);
            }
        }

        
        if (endPoint != null && endFlag)
        {
            if (PlayerPrefs.GetFloat("Score") < score)
            {
                PlayerPrefs.SetFloat("Score", score);
            }     
            endText.SetActive(true);
            endFlag = false;
        }
    }
}

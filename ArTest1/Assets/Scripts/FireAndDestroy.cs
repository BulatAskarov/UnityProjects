using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class FireAndDestroy : MonoBehaviour
{
    
    [SerializeField] private Camera arCamera;

    [SerializeField] private GameObject bullet;
    
    private Vector2 touchPosition = default;

    private float maxEnemies = 0;

    private GameObject[] enemies;

    private int score = 0;
    
    private GameObject startPoint;
    private GameObject endPoint;
    
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject endText;

    [SerializeField]private AudioSource audio;
    
    private bool endFlag = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        startPoint = GameObject.FindGameObjectWithTag("StartPoint");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        endPoint = GameObject.FindGameObjectWithTag("EndPoint");
        if (enemies.Length < maxEnemies)
        {
            score += 10;
            scoreText.text = score.ToString();
            audio.Play();
            maxEnemies = enemies.Length;
            Debug.Log(score);
        }
        else
        {
            maxEnemies = enemies.Length;
        }
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (startPoint != null && touch.phase == TouchPhase.Began)
            {
//                Ray ray = arCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f)); //Луч в центр экрана
//                RaycastHit hitObject;
//                if (Physics.Raycast(ray, out hitObject))
//                {
//                   Destroy(hitObject.transform.transform.gameObject);
//                }
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
        startPoint = null;
    }
}

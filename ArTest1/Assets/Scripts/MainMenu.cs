using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class MainMenu : MonoBehaviour
{

    [SerializeField] private Text score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Best score: " + PlayerPrefs.GetFloat("Score");
    }
    
    public void PlayPressed()
    {
        SceneManager.LoadScene("BubbleUp");
    }
    
    public void ResetPressed()
    {
        PlayerPrefs.SetFloat("Score", 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{


    [SerializeField] private GameObject startPoint;

    [SerializeField] private GameObject conButton;
    [SerializeField] private GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPressed()
    {
        startPoint.SetActive(true);
        startButton.SetActive(false);
    }

    public void PausePressed()
    {
        conButton.SetActive(true);
        startPoint.SetActive(false);
    }

    public void ConPressed()
    {
        conButton.SetActive(false);
        startPoint.SetActive(true);
    }
    
    public void RetPressed()
    {
        SceneManager.LoadScene("BubbleUp");
    }

    public void MenuPressed()
    {
        SceneManager.LoadScene("Menu");
    }
}

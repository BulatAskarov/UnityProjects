using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField]
    private GameObject startPoint;

    
    public void StartPressed()
    {
        Instantiate(startPoint);
    }
}

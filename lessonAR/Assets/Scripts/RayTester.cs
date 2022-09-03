using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RayTester : MonoBehaviour
{
    [SerializeField] private LineRenderer myLineRenderer;
    private ARRaycastManager _arRaycastManager;
    // Start is called before the first frame update
    void Start()
    {
        _arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(transform.position, transform.forward);
        var hits = new List<ARRaycastHit>();
        if (_arRaycastManager.Raycast(ray, hits, TrackableType.Planes))
        {
            myLineRenderer.SetPosition(1, transform.position + transform.forward * hits[0].distance);
            
            myLineRenderer.enabled = true;
            
        }
        else
        {
            myLineRenderer.enabled = false;
        }
    }
}

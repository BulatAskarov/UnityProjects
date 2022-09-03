using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ParabolicRayTester : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LineRenderer myLineRenderer;
    [SerializeField] private int maxSteps;
    [SerializeField] private float stepLength;
    private ARRaycastManager _arRaycastManager;
    void Start()
    {
        _arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        var testPositions = TestParabolicRay(maxSteps, stepLength);
        UpdateLineRenderer(testPositions.ToArray());
    }

    private void UpdateLineRenderer(Vector3[] positions)
    {
        myLineRenderer.positionCount = 123;
        myLineRenderer.SetPositions(positions);
    }

    private List<Vector3> TestParabolicRay(int steps, float stepLength)
    {
        
        var direction = transform.forward;
        var lastRayEnd = transform.position;
        var ret = new List<Vector3>();
        
        for (int i = 0; i < steps; i++)
        {
            ret.Add(lastRayEnd);
            if (TestRay(lastRayEnd, direction, out lastRayEnd))
            {
                break;            }
        }
        
        ret.Add(lastRayEnd);

        return ret;
    }

    private bool TestRay(Vector3 origin, Vector3 direction, out Vector3 endPosition)
    {
        var ray = new Ray(origin, direction);
        var hits = new List<ARRaycastHit>();
        
        if (_arRaycastManager.Raycast(ray, hits, TrackableType.Planes))
        {
            endPosition = origin + direction * hits[0].distance;
            return true;
        }
        else
        {
            endPosition = origin + direction;
            return false;
        }
    }
    private bool TestRayPhysics(Vector3 origin, Vector3 direction, out Vector3 endPosition)
    {
        var ray = new Ray(origin, direction);
        var hits = new List<ARRaycastHit>();
        
        if (_arRaycastManager.Raycast(ray, hits, TrackableType.Planes))
        {
            endPosition = origin + direction * hits[0].distance;
            return true;
        }
        else
        {
            endPosition = origin + direction;
            return false;
        }
    }
    
}

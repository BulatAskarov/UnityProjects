using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARRaycastManager))]
public class CubeWallSpawner : MonoBehaviour
{
    
    [SerializeField]private float period = 5f;
    private float nextSpawnTime = 0.0f;
    private ARRaycastManager arRaycastManager;
    [SerializeField] private GameObject enemy;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    private GameObject endPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }
    // Update is called once per frame
    void Update()
    {
        endPoint = GameObject.FindGameObjectWithTag("EndPoint");
        if (endPoint == null)
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime += period;
                RandomRay();
                var hitPose = hits[0].pose;
                Vector3 hitRot = hitPose.rotation.eulerAngles;
                hitRot.y = 0f;
                hitRot.x = 0f;
                hitRot.z = 0f;
                Instantiate(enemy, hitPose.position, Quaternion.Euler(hitRot));
            }
        }
    }

    private void RandomRay()
    {
        float pose = Random.Range(1, 6);
        switch (pose)
        {
        case 1 : arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits,
            UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
            break;
        case 2 :arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 4), hits,
            UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
            break;
        case 3 : arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 4 * 3), hits,
            UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
             break;
        case 4 : arRaycastManager.Raycast(new Vector2(Screen.width / 4, Screen.height / 2), hits,
            UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
            break;
        case 5 : arRaycastManager.Raycast(new Vector2(Screen.width / 3, Screen.height / 2), hits,
            UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon);
            break;
        }
    }
}

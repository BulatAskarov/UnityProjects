using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class PlacementWithManySelectionController : MonoBehaviour
{

    [SerializeField]
    private PlacementObject[] placedObjects;

    [SerializeField] private Color activeColor = Color.red;

    [SerializeField] private Color inActiveColor = Color.blue;

    [SerializeField] private Camera arCamera;

    private Vector2 touchPosition = default;

   

    private void Awake()
    {
        
        ChangeSelectedObject(placedObjects[0]);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                //Ray ray = arCamera.ScreenPointToRay(touchPosition); //Луч в точку касания
                Ray ray = arCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f)); //Луч в центр экрана
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    PlacementObject placementObject = hitObject.transform.GetComponent<PlacementObject>();
                    if (placementObject != null)
                    {
                        ChangeSelectedObject(placementObject);
                    }
                }
            }
        }
    }

    void ChangeSelectedObject(PlacementObject selected)
    {
        foreach (var current in placedObjects)
        {
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if (selected != current)
            {
                current.IsSelected = false;
                meshRenderer.material.color = inActiveColor;
            }
            else
            {
                current.IsSelected = true;
                meshRenderer.material.color = activeColor;
            }
        }
    }
}

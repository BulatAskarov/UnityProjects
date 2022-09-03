using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReceiver : MonoBehaviour
{
    
    [SerializeField] private InputActionAsset inputMap;

    private InputAction movementAction;
    
    // Start is called before the first frame update
    void Start()
    {
        InputActionMap actionMap = inputMap.FindActionMap("Player");

        movementAction = actionMap.FindAction("Movement");
        movementAction.Enable();

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movementAction.ReadValue<Vector2>());
    }
}

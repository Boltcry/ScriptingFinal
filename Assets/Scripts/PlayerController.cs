using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    public Camera mainCamera;
    private PlayerInput playerInput;
    private InputAction selectAction;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PlayerControllerScript started");
        playerInput = GetComponent<PlayerInput>();
        selectAction = playerInput.actions["select"];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(InputAction.CallbackContext aContext)
    {

        if (aContext.phase == InputActionPhase.Performed)
        {
            Vector2 mouseScreenPosition = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, mainCamera.nearClipPlane));
            Debug.Log("Mouse Clicked!");
            TaskManager.AddTask(TaskManager.TaskType.Move,mouseWorldPosition);
        }

    }

}

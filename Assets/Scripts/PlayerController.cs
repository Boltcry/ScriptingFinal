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
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Clickable"));
            
            
            TaskManager.AddTask(new MoveTask(mouseWorldPosition));
            

            //Check if player selected a ClickableObject
            if (hit.collider != null)
            {
                Debug.Log("Clicked on object in the 'clickable' layer: " + hit.collider.gameObject.name);
                ClickableObject clickableObject = hit.collider.gameObject.GetComponent<ClickableObject>();
                if (clickableObject != null)
                {
                    TaskManager.AddTask(new ClickablePressedTask(mouseWorldPosition, clickableObject));
                }
            }
        }

    }

}

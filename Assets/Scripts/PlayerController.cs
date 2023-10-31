using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


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
            Debug.Log("Mouse Clicked!");
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{


    public Camera mainCamera;
    private PlayerInput playerInput;
    private InputAction selectAction;
    private Vector3 lastPosition;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    public float xDirection = 0;
    public float yDirection = 0;
    public bool isCarryingFood = false;



    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        selectAction = playerInput.actions["select"];

        spriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
        lastPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sortingOrder = Mathf.FloorToInt(-transform.position.y * 10);

        UpdateDirection();
        lastPosition = transform.position;

        anim.SetFloat("xDirection", xDirection);
        anim.SetFloat("yDirection", yDirection);


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
                ClickableObject clickableObject = hit.collider.gameObject.GetComponent<ClickableObject>();
                if (clickableObject != null)
                {
                    Debug.Log("Added clickable task");
                    TaskManager.AddTask(new ClickablePressedTask(mouseWorldPosition, clickableObject));
                }
            }
        }

    }

    void UpdateDirection()
    {
        // Calculate direction vector for animation
        Vector3 direction = transform.position - lastPosition;

        direction.Normalize();

        xDirection = direction.x;
        yDirection = direction.y;
    }

}

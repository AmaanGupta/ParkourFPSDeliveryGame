using System;

using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController characterController;
    
    

    [Header("VELOCITIESS")] 
    [SerializeField] private Vector3 finalMove;
    [SerializeField] private Vector3 verticalMove;
    [SerializeField] private Vector3 horizontalMove;

    [Header("FPP CAMERA")] 
    [SerializeField] private GameObject cinemachineCamera;

    
    private Vector2 inputmoveDirection;
    [Header("INPUT ACTION REFRENCES")] 
    
    [SerializeField] private InputActionReference move;
    
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference sprint;
    private bool isJump=false;
    

    private float constantmovementSpeed=2f;
    private float movementSpeed;
    private float jumpHeight=1.3f;
    private float sprintMultiplier=2f;
    const float GRAVITY=18f;

    void Awake()
    {
        characterController=GetComponent<CharacterController>();
    }
    void OnEnable()
        {
            movementSpeed=constantmovementSpeed;
            


            jump.action.started += Jump;
            sprint.action.started += StartSprint;
            sprint.action.canceled += StopSprint;
        }
    void OnDisable()
        {
            jump.action.started -= Jump;
            sprint.action.started -= StartSprint;
            sprint.action.canceled -= StopSprint;
        }

    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }
    void Update()
    {
        
        MovementInput();
        ResultantMovePlayer(HorizontalMovement(),VerticalMovement());
    }

    void LateUpdate()
    {
        transform.rotation=Quaternion.Euler(0,cinemachineCamera.transform.eulerAngles.y,0);
    }



    void MovementInput()
    {
        inputmoveDirection=move.action.ReadValue<Vector2>();
    }

    private Vector3 HorizontalMovement()
    {
        Vector3 horizontalmoveVector= new Vector3(inputmoveDirection.x,0,inputmoveDirection.y).normalized;
        horizontalMove= transform.TransformDirection(horizontalmoveVector);
        return horizontalMove;
        
    }

    private Vector3 VerticalMovement()
    {
        
        if (characterController.isGrounded)
        {
            verticalMove.y=-2f;
        }
         
        if (isJump)
        {
            verticalMove.y=(float)Math.Sqrt(2*GRAVITY*jumpHeight);
            isJump=false;
        }
        verticalMove.y-=GRAVITY*Time.deltaTime;
        return verticalMove;

    }

    void Jump(InputAction.CallbackContext obj)
    {
        if (characterController.isGrounded)
        {
            isJump=true;
        }
        
        
    }

    void StartSprint(InputAction.CallbackContext obj)
    {
        movementSpeed=constantmovementSpeed*sprintMultiplier;
    }
    void StopSprint(InputAction.CallbackContext obj)
    {
        movementSpeed=constantmovementSpeed;
    }



    void ResultantMovePlayer(Vector3 horizontalMove, Vector3 verticalMove)
    {
        finalMove=horizontalMove*movementSpeed+verticalMove;
        characterController.Move(finalMove*Time.deltaTime);
        
    }

    

}

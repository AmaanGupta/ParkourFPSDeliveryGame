using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController characterController;
    [SerializeField] private  PlayerManager playerManager;
    public bool isClimb;
    
    

    [Header("VELOCITIESS")] 
    [SerializeField] private Vector3 finalMove;
    [SerializeField] private Vector3 verticalMove;
    [SerializeField] private Vector3 horizontalMove;

    [Header("FPP CAMERA")] 
    [SerializeField] private CinemachineCamera cinemachineCamera;

    
    private Vector2 inputmoveDirection;
    [Header("INPUT ACTION REFRENCES")] 
    
    [SerializeField] private InputActionReference move;
    
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference sprint;
    private float targetFOV=60f;

    private bool isJump=false;
    

    private float constantmovementSpeed=5f;
    private float movementSpeed;
    private float jumpHeight=1.3f;
    private float sprintMultiplier=2f;
    
    const float GRAVITY=18f;
    [SerializeField] private float coyoteCounter=0f;
    private float coyoteTimer=0.2f;
    [SerializeField] private float jumpBufferCounter=0f;
    private float jumpBufferTimer=0.2f;
    
    [SerializeField] private bool requiredIsGrounded=false;

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
        GroundCheck();
        JumpBuffer();
        SprintInterpolator();
        
        
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
        horizontalMove=Vector3.Lerp(horizontalMove,transform.TransformDirection(horizontalmoveVector),5f*Time.deltaTime);
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
            coyoteCounter=0f;
            verticalMove.y=Mathf.Sqrt(2*GRAVITY*jumpHeight);
            isJump=false;
        }
        verticalMove.y-=GRAVITY*Time.deltaTime;
        return verticalMove;

    }

    void Jump(InputAction.CallbackContext obj)
    {
        if (playerManager.currentState == PlayerManager.PlayerState.LedgeGrab)
        {
            isClimb=true;
            
        }
        else if(playerManager.currentState == PlayerManager.PlayerState.Normal)
        {
            if (requiredIsGrounded)
            {
                isJump=true;      
            }

            if (!requiredIsGrounded)
            {
                jumpBufferCounter=jumpBufferTimer;

            }
        }
    }

    void JumpBuffer()
    {
        
        jumpBufferCounter-=Time.deltaTime;
        if (requiredIsGrounded && jumpBufferCounter>0)
        {
            isJump=true;
            jumpBufferCounter=0f;
        }
        

    }
    

    void StartSprint(InputAction.CallbackContext obj)
    {
        if (requiredIsGrounded)
        {
            movementSpeed=constantmovementSpeed*sprintMultiplier;
            if (inputmoveDirection!=new Vector2(0, 0))
            {
                targetFOV=90;
            }
        }
        
        
    }
    void SprintInterpolator()
    {
        cinemachineCamera.Lens.FieldOfView=Mathf.Lerp(cinemachineCamera.Lens.FieldOfView,targetFOV,2f*Time.deltaTime);
    }
    void StopSprint(InputAction.CallbackContext obj)
    {
        targetFOV=60f;
        movementSpeed=constantmovementSpeed;
    }



    void ResultantMovePlayer(Vector3 horizontalMove, Vector3 verticalMove)
    {
        finalMove=horizontalMove*movementSpeed+verticalMove;
        characterController.Move(finalMove*Time.deltaTime);
        
    }

    public void ExecuteMovement()
    {
        
        ResultantMovePlayer(HorizontalMovement(),VerticalMovement());
    }


    void GroundCheck(){
        if(characterController.isGrounded)
        {
            coyoteCounter=coyoteTimer;
        }

        if (!characterController.isGrounded)
        {
            coyoteCounter-=Time.deltaTime;
        }
        requiredIsGrounded = coyoteCounter > 0;


    }
    
    

}

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
    private bool isJump=false;
    

    private float movementSpeed=4f;
    private float jumpHeight=1f;
    const float GRAVITY=9.81f;
    void Awake()
        {
            characterController=GetComponent<CharacterController>();
            jump.action.started+=Jump;
        }
    void OnEnable()
        {
            jump.action.started += Jump;
        }
    void OnDisable()
        {
            jump.action.started -= Jump;
        }
    void Update()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
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
        isJump=true;
        
    }

    void ResultantMovePlayer(Vector3 horizontalMove, Vector3 verticalMove)
    {
        finalMove=horizontalMove*movementSpeed+verticalMove;
        characterController.Move(finalMove*Time.deltaTime);
        
    }

    

}

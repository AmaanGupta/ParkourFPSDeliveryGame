using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("Player Fields")] 
    private PlayerContext player;
    



    [Header("INPUT ACTION REFRENCES")] 
    
    [SerializeField] private InputActionReference move;
    
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference sprint;
    [SerializeField] private InputActionReference crouch;
    [SerializeField] private InputActionReference look;


    [Header("Public Input Variables")] 

    public bool isJump;
    public bool isSprinting {get; private set;}
    public bool isCrouching {get; private set;}
    public Vector2 inputmoveDirection{get;private set;}
    public Vector2 lookInput{get;private set;}


    void Awake()
    {
        player=GetComponent<PlayerContext>();
    }
    
    void OnEnable()
        {
            jump.action.started += Jump;
            sprint.action.started += StartSprint;
            sprint.action.canceled += StopSprint;
            crouch.action.started += Crouch;
            
        }

    void OnDisable()
        {
            jump.action.started -= Jump;
            sprint.action.started -= StartSprint;
            sprint.action.canceled -= StopSprint;
            crouch.action.started -= Crouch;
            
        }

    void Jump(InputAction.CallbackContext obj)
    {
        
        isJump=true;
    }

    public bool IsJumpPressed()
    {
        if (!isJump) return false;

        isJump = false;
        return true;
    }

    

    void StartSprint(InputAction.CallbackContext obj)
    {
        isSprinting=true;
    }
    
    void StopSprint(InputAction.CallbackContext obj)
    {
        isSprinting=false;
    }
    void Crouch(InputAction.CallbackContext obj)
    {
        isCrouching=!isCrouching;
    }
    
    

    void Update()
    {
        Debug.Log($"Cached: {inputmoveDirection}");
        inputmoveDirection=move.action.ReadValue<Vector2>();
        lookInput=look.action.ReadValue<Vector2>();
        
    }



    
    


}

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
    [SerializeField] private InputActionReference interact;
    


    [Header("Public Input Variables")] 

    public bool isJump;
    public bool isInteract;
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
            interact.action.started += Interact;
            sprint.action.started += StartSprint;
            sprint.action.canceled += StopSprint;
            crouch.action.started += Crouch;
            
        }

    void OnDisable()
        {
            jump.action.started -= Jump;
            interact.action.started += Interact;
            sprint.action.started -= StartSprint;
            sprint.action.canceled -= StopSprint;
            crouch.action.started -= Crouch;
            
        }

    void Jump(InputAction.CallbackContext obj)
    {
        if(player.canJump) isJump=true;
        
    }

    public bool IsJumpPressed()
    {
        if (!isJump) return false;

        isJump = false;
        return true;
    }
    void Interact(InputAction.CallbackContext obj)
    {
        
        if(player.canInteract) isInteract=true;
    }

    public bool IsInteractPressed()
    {
        if (!isInteract) return false;

        isInteract = false;
        return true;
    }

    

    void StartSprint(InputAction.CallbackContext obj)
    {
        if(player.canSprint) isSprinting=true;
    }
    
    void StopSprint(InputAction.CallbackContext obj)
    {
        if(player.canSprint) isSprinting=false;
    }
    void Crouch(InputAction.CallbackContext obj)
    {
        if(player.canCrouch) isCrouching=!isCrouching;
    }
    
    

    void Update()
    {
        
        if(player.canMove) inputmoveDirection=move.action.ReadValue<Vector2>();
        if(player.canAim) lookInput=look.action.ReadValue<Vector2>();
        
    }



    
    


}

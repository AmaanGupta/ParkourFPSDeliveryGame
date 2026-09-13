using UnityEngine;
using Unity.Cinemachine;

public class PlayerContext : MonoBehaviour
{


    [Header("Player Must Have")] 
    public PlayerMotor PlayerMotor{get; private set;}
    public PlayerInput PlayerInput{get; private set;}
    public PlayerAnimator PlayerAnimator{get; private set;}



    [Header("FPP CAMERA")] 
    [SerializeField] private CinemachineCamera cinemachineCamera;
    private PlayerStateMachine stateMachine;




    [Header("STATES")] 
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerLocomotionState LocomotionState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }




    [Header("Speeds")] 

    private float constantmovementSpeed=5f;
    public float ConstantMovementSpeed=> constantmovementSpeed;
    
    public float MovementSpeed;




    [Header("Jump Var")] 
    private float jumpHeight=2f;
    public float JumpHeight=> jumpHeight;
    private float sprintMultiplier=2f;
    public float SprintMultiplier=>sprintMultiplier;
    
    public float jumpBufferTimer=0.2f;
    
    const float gravity=18f;
    public float GRAVITY => gravity;



    void Awake()
    {
        PlayerMotor=GetComponent<PlayerMotor>();
        PlayerInput=GetComponent<PlayerInput>();
        PlayerAnimator=GetComponent<PlayerAnimator>();


        stateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, stateMachine);
        LocomotionState = new PlayerLocomotionState(this, stateMachine);
        FallState = new PlayerFallState(this, stateMachine);
        JumpState = new PlayerJumpState(this, stateMachine);
    }
    
    void Start()
    {
        stateMachine.Initialize(IdleState);
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    
    void Update()
    {
        stateMachine.CurrentState.Update();
        // Debug.Log(stateMachine.CurrentState);
    }
}

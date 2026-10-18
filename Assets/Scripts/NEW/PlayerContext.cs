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
    public PlayerSprintState SprintState { get; private set; }
    public PlayerCrouchState CrouchState { get; private set; }
    

    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }




    [Header("Speeds")] 

    private float constantmovementSpeed=3f;
    public float ConstantMovementSpeed=> constantmovementSpeed;
    private float sprintMovementSpeed=5f;
    public float SprintMovementSpeed=> sprintMovementSpeed;
    private float crouchMovementSpeed=2f;
    public float CrouchMovementSpeed=> crouchMovementSpeed;
    
    public float MovementSpeed;




    [Header("Jump Var")] 
    private float jumpHeight=2f;
    public float JumpHeight=> jumpHeight;
    
    
    public float jumpBufferTimer=0.2f;
    
    const float gravity=10;
    public float GRAVITY => gravity;

    [Header("Camera Tracker")] 
    [SerializeField] private Transform cameraTracker;
    public Transform CameraTracker => cameraTracker;
    
    
    private float normalHeight=0.87f;
    public float NormalHeight => normalHeight;
    private float crouchedHeight=0.42f;
    public float CrouchedHeight => crouchedHeight;
    public float TargetHeigh;





    void Awake()
    {
        TargetHeigh=normalHeight;
        PlayerMotor=GetComponent<PlayerMotor>();
        PlayerInput=GetComponent<PlayerInput>();
        PlayerAnimator=GetComponent<PlayerAnimator>();


        stateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, stateMachine);
        LocomotionState = new PlayerLocomotionState(this, stateMachine);
        SprintState = new PlayerSprintState(this, stateMachine);
        CrouchState = new PlayerCrouchState(this, stateMachine);
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
        Debug.Log(stateMachine.CurrentState);
    }
}

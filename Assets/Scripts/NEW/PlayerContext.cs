using UnityEngine;
using Unity.Cinemachine;

public class PlayerContext : MonoBehaviour
{
    [Header("FPP CAMERA")] 
    [SerializeField] private CinemachineCamera cinemachineCamera;
    private PlayerStateMachine stateMachine;
    public PlayerIdleState IdleState { get; private set; }

    private float constantmovementSpeed=5f;
    public float ConstantMovementSpeed=> constantmovementSpeed;
    private float movementSpeed;
    public float MovementSpeed=> movementSpeed;
    private float jumpHeight=1.3f;
    public float JumpHeight=> jumpHeight;
    private float sprintMultiplier=2f;
    public float SprintMultiplier=>sprintMultiplier;
    
    const float gravity=18f;
    public float GRAVITY => gravity;


    void Awake()
    {
        stateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, stateMachine);
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}

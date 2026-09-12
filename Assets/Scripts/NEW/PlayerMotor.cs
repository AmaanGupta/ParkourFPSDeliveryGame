using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [Header("Player Must Haves")] 
    private PlayerInput playerInput;
    private PlayerContext playerContext;
    private CharacterController characterController;


    [Header("VELOCITIESS")] 
    public Vector3 finalMove;
    public Vector3 verticalMove;
    public Vector3 horizontalMove;


    private float mouseSensitivity=0.1f;


    
    


    
    [SerializeField] private float coyoteCounter=0f;
    private float coyoteTimer=0.2f;
    [SerializeField] private float jumpBufferCounter=0f;
    private float jumpBufferTimer=0.2f;
    
    [SerializeField] private bool requiredIsGrounded=false;

    void Awake()
    {
        characterController=GetComponent<CharacterController>();
        playerInput=GetComponent<PlayerInput>();
        playerContext=GetComponent<PlayerContext>();
    }
        
    
    public void HandleMovement()
    {
        CameraX();
        playerContext.MovementSpeed=playerContext.ConstantMovementSpeed;
        ResultantMovePlayer(HorizontalMovement(),VerticalMovement());
    }

    void CameraX()
    {
        float mouseX=playerInput.lookInput.x*mouseSensitivity;
        transform.Rotate(Vector3.up*mouseX);
    }
    private Vector3 HorizontalMovement()
    {
        Vector3 horizontalmoveVector= new Vector3(playerInput.inputmoveDirection.x,0,playerInput.inputmoveDirection.y);
        horizontalMove=Vector3.Lerp(horizontalMove,transform.TransformDirection(horizontalmoveVector),5f*Time.deltaTime);
        return horizontalMove;
    }

    private Vector3 VerticalMovement()
    {
        verticalMove.y=-2f;
        verticalMove.y-=playerContext.GRAVITY*Time.deltaTime;
        return verticalMove;
    }
    void ResultantMovePlayer(Vector3 horizontalMove, Vector3 verticalMove)
    {
        finalMove=horizontalMove* playerContext.MovementSpeed+verticalMove;
        characterController.Move(finalMove*Time.deltaTime);
        
    }
}

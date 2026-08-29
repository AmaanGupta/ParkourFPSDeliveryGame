using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController characterController;

    [Header("VELOCITIESS")] 
    [SerializeField] private Vector3 finalMove;
    [SerializeField] private Vector3 verticalMove;
    [SerializeField] private Vector3 horizontalMove;


    private bool isJump=false;
    

    
    [SerializeField] private float coyoteCounter=0f;
    private float coyoteTimer=0.2f;
    [SerializeField] private float jumpBufferCounter=0f;
    private float jumpBufferTimer=0.2f;
    
    [SerializeField] private bool requiredIsGrounded=false;

    void Awake()
    {
        characterController=GetComponent<CharacterController>();
    }
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

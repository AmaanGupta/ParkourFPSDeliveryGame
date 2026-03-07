using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    
    private CharacterController characterController;
    
    private Vector2 moveDirection1;



    [SerializeField] private GameObject cinemachineCamera;
    
    [SerializeField] private InputActionReference move;
    void Awake()
    {
        characterController=GetComponent<CharacterController>();
    }

    void Update()
    {
        MovementInput();
        MovePlayer(NormalAndLocal());
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible=false;
    }

    void LateUpdate()
    {
        transform.rotation=Quaternion.Euler(0,cinemachineCamera.transform.eulerAngles.y,0);
    }



    void MovementInput()
    {
        moveDirection1=move.action.ReadValue<Vector2>();
    }

    private Vector3 NormalAndLocal()
    {
        Vector3 moveVector= new Vector3(moveDirection1.x,0,moveDirection1.y).normalized;
        return transform.TransformDirection(moveVector);
        
    }

    void MovePlayer(Vector3 moveVector)
    {
        characterController.Move(moveVector*Time.deltaTime*2f);
    }

}

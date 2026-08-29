using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [Header("Player Fields")] 
    [SerializeField] private PlayerContext player;



    private Vector2 inputmoveDirection;
    [SerializeField] private Vector2 lookInput;

    [Header("INPUT ACTION REFRENCES")] 
    
    [SerializeField] private InputActionReference move;
    
    [SerializeField] private InputActionReference jump;
    [SerializeField] private InputActionReference sprint;
    [SerializeField] private InputActionReference look;
    

    private float targetFOV=60f;
    private float mouseSensitivity=0.1f;
    void OnEnable()
        {
            player.MovementSpeed=player.ConstantMovementSpeed;
            


            jump.action.started += Jump;
            sprint.action.started += StartSprint;
            sprint.action.canceled += StopSprint;
        }

    
    


}

using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    public enum PlayerState
    {
        None,
        
        Grounded,
        Sprinting,
        Falling,
        LedgeGrabbing
    }

    PlayerState currentState=PlayerState.None;
    [SerializeField] private FallingState fallingScript;
    [SerializeField] private GroundedState groundedScript;
    [SerializeField] private LedgeGrabbingState ledgeGrabbingScript;
    [SerializeField] private SprintingState sprintingScript;

    void Start()
    {
        
    }

    void Update()
    {
        if (currentState==PlayerState.None)return;
        switch (currentState)
        {
            case PlayerState.Falling:fallingScript.StateUpdate();break;
            case PlayerState.Grounded:groundedScript.StateUpdate();break;
            case PlayerState.Sprinting:sprintingScript.StateUpdate();break;
            case PlayerState.LedgeGrabbing:ledgeGrabbingScript.StateUpdate();break;
        }
    }

    void ChangeState(PlayerState newState)
    {
        ExitState(currentState);
        currentState=newState;
        EnterState(currentState);

    }

    void EnterState(PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Falling:fallingScript.StateEntry();break;
            case PlayerState.Grounded:groundedScript.StateEntry();break;
            case PlayerState.Sprinting:sprintingScript.StateEntry();break;
            case PlayerState.LedgeGrabbing:ledgeGrabbingScript.StateEntry();break;
        }
    }

    void ExitState( PlayerState state)
    {
        switch (state)
        {
            case PlayerState.Falling:fallingScript.StateExit();break;
            case PlayerState.Grounded:groundedScript.StateExit();break;
            case PlayerState.Sprinting:sprintingScript.StateExit();break;
            case PlayerState.LedgeGrabbing:ledgeGrabbingScript.StateExit();break;
        }
    }
}

using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public enum PlayerState
    {
        Normal,
        LedgeGrab
    }
    public PlayerState currentState;
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private LedgeGrab ledgeGrabScript;

    void Start()
    {
        currentState=PlayerState.Normal;
    }
    void Update()
    {
        switch (currentState)
        {
            case PlayerState.Normal:
                UpdateNormal();
                break;
            case PlayerState.LedgeGrab:
                UpdateLedgeGrab();
                break;
        }

    }
    void UpdateNormal()
    {
        if (ledgeGrabScript.isledgeGrab)
        {
            ledgeGrabScript.climbCompleted=false;
            

            currentState=PlayerState.LedgeGrab;
            playerMovementScript.isClimb=false;
        }
        playerMovementScript.ExecuteMovement();
        

    }
    void UpdateLedgeGrab()
    {
        if (ledgeGrabScript.climbCompleted)
        {
            currentState=PlayerState.Normal;
        }
        ledgeGrabScript.LedgeClimb();
    }
    


}

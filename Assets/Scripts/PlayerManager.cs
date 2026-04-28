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
            currentState=PlayerState.LedgeGrab;
        }
        playerMovementScript.ExecuteMovement();
        

    }
    void UpdateLedgeGrab()
    {
        
        ledgeGrabScript.LedgeClimb();
    }
    


}

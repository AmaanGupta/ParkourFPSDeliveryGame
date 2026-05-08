using Unity.Cinemachine;
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
    [SerializeField] private Animator bodyAnim;
    [SerializeField] private Animator onlyHandsAnim;
    [SerializeField] private GameObject cam;

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
            
            ledgeGrabScript.climbCompleted=false;
            currentState=PlayerState.LedgeGrab;

            playerMovementScript.isClimb=false;

            onlyHandsAnim.SetTrigger("Hang");
            bodyAnim.SetTrigger("Hang");

            cam.GetComponent<CinemachinePanTilt>().PanAxis.Wrap=false;
            cam.GetComponent<CinemachinePanTilt>().PanAxis.Range=new Vector2(-150,-30);
        }
        playerMovementScript.ExecuteMovement();
        

    }
    void UpdateLedgeGrab()
    {
        if (ledgeGrabScript.climbCompleted)
        {
            cam.GetComponent<CinemachinePanTilt>().PanAxis.Wrap=true;
            cam.GetComponent<CinemachinePanTilt>().PanAxis.Range=new Vector2(-180,180);
            currentState=PlayerState.Normal;
        }
        ledgeGrabScript.LedgeClimb();
    }
    


}

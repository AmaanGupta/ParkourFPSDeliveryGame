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
            transform.rotation=Quaternion.Euler(0,ledgeGrabScript.ledgeTransform.rotation.eulerAngles.y,0);
            CinemachineTakesOver(true);
            

            ledgeGrabScript.climbCompleted=false;
            
            ledgeGrabScript.climbCompleted=false;
            currentState=PlayerState.LedgeGrab;

            playerMovementScript.isClimb=false;

            onlyHandsAnim.SetTrigger("Hang");
            bodyAnim.SetTrigger("Hang");

            cam.GetComponent<CinemachinePanTilt>().PanAxis.Wrap=false;
            cam.GetComponent<CinemachinePanTilt>().PanAxis.Range=new Vector2(-45,45);
        }
        playerMovementScript.ExecuteMovement();
        

    }
    void UpdateLedgeGrab()
    {
        if (ledgeGrabScript.climbCompleted)
        {
            cam.GetComponent<CinemachinePanTilt>().PanAxis.Value=0;
            CinemachineTakesOver(false);
            currentState=PlayerState.Normal;
        }
        ledgeGrabScript.LedgeClimb();
    }

    void CinemachineTakesOver(bool boolean)
    {
        CinemachineInputAxisController controllerComponent = cam.GetComponent<CinemachineInputAxisController>();
        foreach (var controller in controllerComponent.Controllers) 
        {
            if (controller.Name == "Look X (Pan)")
            {
                controller.Enabled=boolean;
            }
        }
    }
    


}

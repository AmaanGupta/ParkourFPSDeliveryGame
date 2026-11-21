using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerPunchState : PlayerBaseState
{
    
    public PlayerPunchState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    float punchTime;
    float maxPunchTime=2f;
    Vector3 selectedCentre;
    



    public override void Enter()
    {
        punchTime=maxPunchTime;
        Punch();
     
    }


    public override void Update()
    {
        punchTime-=Time.deltaTime;
        player.PlayerMotor.HandleMovement();
        player.PlayerAnimator.HandleAnimation();
        if (punchTime <= 0)
        {
            stateMachine.ChangeState(player.IdleState);
            return;
        }
        
        
       
          
    }
    public override void Exit()
    {
        
        
    }

    private void Punch()
    {
        if(Physics.Raycast(player.CinemachineCamera.transform.position,player.CinemachineCamera.transform.forward,out RaycastHit hit, 1f,player.PunchableLayer))
        {
            selectedCentre=hit.collider.transform.position;
       
            Collider[] hits = Physics.OverlapSphere(selectedCentre,1f,player.PunchableLayer);

            foreach (Collider c in hits)
            {
                Debug.Log($"Punching {c.name}");
                Rigidbody rb=c.gameObject.GetComponent<Rigidbody>();
                
                rb.isKinematic=false;
                rb.AddForce(player.CinemachineCamera.transform.forward * 20f, ForceMode.Impulse);
            }

            
        }
        
    }

    
}
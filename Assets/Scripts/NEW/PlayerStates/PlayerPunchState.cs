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
    float maxPunchTime=0.1f;
    Vector3 selectedCentre;
    



    public override void Enter()
    {
        player.canInteract=false;
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
        player.canInteract=true;
        
        
    }

    private void Punch()
    {
        if(Physics.Raycast(player.CinemachineCamera.transform.position,player.CinemachineCamera.transform.forward,out RaycastHit hit, 1f,player.PunchableLayer))
        {
            selectedCentre=hit.collider.transform.position;
       
            Collider[] hits = Physics.OverlapSphere(selectedCentre,1.6f,player.PunchableLayer);
            Vector3 explosionOrigin = selectedCentre-player.CinemachineCamera.transform.forward*0.5f;

            foreach (Collider c in hits)
            {
                Debug.Log($"Punching {c.name}");
                Rigidbody rb = c.gameObject.GetComponent<Rigidbody>();
               
                rb.isKinematic=false;
                rb.AddExplosionForce( 6f ,explosionOrigin, 10f , 0.3f , ForceMode.Impulse);
            }

            
        }
        
    }

    
}
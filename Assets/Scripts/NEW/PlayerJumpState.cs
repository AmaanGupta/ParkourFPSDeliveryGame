using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    
    public PlayerJumpState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        
        player.PlayerMotor.verticalMove.y=Mathf.Sqrt(2*player.GRAVITY*player.JumpHeight);
        
        Debug.Log("jumping");
        
        
        
    }


    public override void Update()
    {
        if (player.PlayerMotor.CheckGrounded())
        {
            if (player.PlayerInput.inputmoveDirection.magnitude <= 0.1)
            {
                stateMachine.ChangeState(player.IdleState);
                return;
            }
            else
            {
                stateMachine.ChangeState(player.LocomotionState);
                return;
            } 
        }
        
        player.PlayerAnimator.HandleAnimation();
        player.PlayerMotor.HandleMovement();
        
        
        
    }
    
}
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.PlayerAnimator.FallAnimation(true);
     
    }


    public override void Update()
    {
        
        player.PlayerMotor.ApplyGravity();

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
    public override void Exit()
    {
        player.PlayerAnimator.FallAnimation(false);
     
    }
    
}
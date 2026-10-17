using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    
    public PlayerCrouchState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.MovementSpeed=player.CrouchMovementSpeed;
        player.PlayerAnimator.CrouchAnimation(true);
        
    }


    public override void Update()
    {
        

        player.PlayerMotor.HandleMovement();
        player.PlayerAnimator.HandleAnimation();
        if (!player.PlayerInput.isCrouching)
        {
            stateMachine.ChangeState(player.LocomotionState);
            return;
        }
        
        
        if (!player.PlayerMotor.CheckGrounded())
        {
            stateMachine.ChangeState(player.FallState);
            return;
        }
        
        
    }
    public override void Exit()
    {
        player.PlayerAnimator.CrouchAnimation(false);
        
    }
    
}
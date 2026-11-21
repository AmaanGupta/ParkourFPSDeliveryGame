using UnityEngine;

public class PlayerCrouchState : PlayerBaseState
{
    
    public PlayerCrouchState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.PlayerMotor.SetCrouchingCamera(true);
        player.MovementSpeed=player.CrouchMovementSpeed;
        player.PlayerAnimator.CrouchAnimation(true);
        player.canJump=false;
        
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
        player.PlayerMotor.SetCrouchingCamera(false);
        player.PlayerAnimator.CrouchAnimation(false);
        player.canJump=true;
        
    }
    
}
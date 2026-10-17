using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    
    public PlayerSprintState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.MovementSpeed=player.SprintMovementSpeed;
        player.PlayerAnimator.SprintAnimation(true);
        
        
    }


    public override void Update()
    {
        player.PlayerMotor.HandleMovement();
        player.PlayerAnimator.HandleAnimation();
        if (!player.PlayerInput.isSprinting)
        {
            stateMachine.ChangeState(player.LocomotionState);
            return;
        }
        if (player.PlayerInput.inputmoveDirection.magnitude <= 0.1f)
        {
            stateMachine.ChangeState(player.IdleState);
            return;
        }
        if (player.PlayerInput.IsJumpPressed())
        {
            stateMachine.ChangeState(player.JumpState);
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
        player.PlayerAnimator.SprintAnimation(false);
        
    }

    
}
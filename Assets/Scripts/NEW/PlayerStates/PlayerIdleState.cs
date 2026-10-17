using System.Data;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    
    public PlayerIdleState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        
        
        
    }


    public override void Update()
    {
        
        player.PlayerAnimator.HandleAnimation();
        player.PlayerMotor.HandleMovement();

        if (player.PlayerInput.inputmoveDirection.magnitude > 0.1f)
        {
            stateMachine.ChangeState(player.LocomotionState);
            return;
        }
        if (player.PlayerInput.isCrouching)
        {
            stateMachine.ChangeState(player.CrouchState);
            return;
        }

        if (!player.PlayerMotor.CheckGrounded())
        {
            stateMachine.ChangeState(player.FallState);
            return;
        }
        
        if (player.PlayerInput.IsJumpPressed())
        {
            stateMachine.ChangeState(player.JumpState);
            return;
        }
        
        
    }
    
}
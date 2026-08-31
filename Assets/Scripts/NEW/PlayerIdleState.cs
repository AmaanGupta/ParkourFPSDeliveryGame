using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    
    public PlayerIdleState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.PlayerAnimator.BodyAnim.SetBool("Move",false);
        player.PlayerAnimator.OnlyHandsAnim.SetBool("Move",false);
        
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
        
        
    }
    
}
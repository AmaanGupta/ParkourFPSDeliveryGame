using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    
    public PlayerJumpState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        
        
        
    }


    public override void Update()
    {
        player.PlayerMotor.verticalMove.y=Mathf.Sqrt(2*player.GRAVITY*player.JumpHeight);
        player.PlayerAnimator.HandleAnimation();
        player.PlayerMotor.HandleMovement();
        
        
        
    }
    
}
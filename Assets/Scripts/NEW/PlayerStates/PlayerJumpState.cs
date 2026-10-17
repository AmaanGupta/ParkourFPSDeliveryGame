using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    
    public PlayerJumpState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }
    private float jumpDelay;

    public override void Enter()
    {
        player.PlayerAnimator.JumpAnimation(true);
        jumpDelay=0.2f;
        player.PlayerMotor.verticalMove.y=Mathf.Sqrt(2*player.GRAVITY*player.JumpHeight);
        
        
        
        
        
    }


    public override void Update()
    {
        player.jumpBufferTimer-=Time.deltaTime;
        if (player.PlayerInput.IsJumpPressed())   
        {
            player.jumpBufferTimer=0.2f;

        }
        if (player.jumpBufferTimer >= 0)
        {
            if (player.PlayerMotor.CheckGrounded())
            {
                stateMachine.ChangeState(player.JumpState);
                return;
            }
        }

        jumpDelay-=Time.deltaTime;
        if (jumpDelay <= 0)
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
        }
        
        
        
        player.PlayerAnimator.HandleAnimation();
        player.PlayerMotor.HandleMovement();
        
        
        
    }
    public override void Exit()
    {
        player.PlayerAnimator.JumpAnimation(false);
        
        
        
        
        
        
    }
}
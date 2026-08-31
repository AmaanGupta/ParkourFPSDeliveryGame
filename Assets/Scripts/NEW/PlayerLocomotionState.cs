using UnityEngine;

public class PlayerLocomotionState : PlayerBaseState
{
    private int currentIdleIndex;
    private float idleTimer;
    public PlayerLocomotionState(PlayerContext player,
                           PlayerStateMachine stateMachine): base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        player.PlayerAnimator.BodyAnim.SetBool("Move",true);
        player.PlayerAnimator.OnlyHandsAnim.SetBool("Move",true);
        
    }


    public override void Update()
    {
        player.PlayerMotor.HandleMovement();
        if (player.PlayerInput.inputmoveDirection.magnitude <= 0.1f)
        {
            stateMachine.ChangeState(player.IdleState);
            return;
        }
        
        
    }
    
}
using UnityEngine;

public abstract class PlayerBaseState
{
    protected PlayerContext player;
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerContext player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }
}
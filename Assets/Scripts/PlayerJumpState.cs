using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerStateMachine.StateBase
{
    public PlayerJumpState(StateMachine<PlayerStateMachine.StateCodes, Player> stateMachine) : base(stateMachine)
    {
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
    }

    public override void FixedTick()
    {
        throw new System.NotImplementedException();
    }
}

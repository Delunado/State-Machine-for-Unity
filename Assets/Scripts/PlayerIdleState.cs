using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateMachine.StateBase
{
    public PlayerIdleState(StateMachine<PlayerStateMachine.StateCodes, Player> stateMachine) : base(stateMachine)
    {
    }

    public override void Tick()
    {
        //Código en Update: input, update de variables, etc.

        if (Owner.JumpButtonPressed())
        {
            stateMachine.ChangeState(PlayerStateMachine.StateCodes.JUMP);
        }
    }

    public override void FixedTick()
    {
        //Código en Fixed Update
    }
}

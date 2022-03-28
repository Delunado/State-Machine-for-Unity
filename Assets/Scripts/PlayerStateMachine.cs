using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine<PlayerStateMachine.StateCodes, Player>
{
    public enum StateCodes
    {
        IDLE,
        RUN,
        JUMP
    }

    public PlayerStateMachine(Player owner) : base(owner)
    {
        AddState(StateCodes.IDLE, new PlayerIdleState(this));
        AddState(StateCodes.RUN, new PlayerRunState(this));
        AddState(StateCodes.JUMP, new PlayerJumpState(this));
    }
}

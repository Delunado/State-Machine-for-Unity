using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerStateMachine stateMachine;
    
    void Start()
    {
        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(PlayerStateMachine.StateCodes.IDLE);
    }
    
    void Update()
    {
        stateMachine.Tick();
    }

    private void FixedUpdate()
    {
        stateMachine.FixedTick();
    }

    public bool JumpButtonPressed()
    {
        return true;
    }
}

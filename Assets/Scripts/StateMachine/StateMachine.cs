using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public class StateMachine<TStateCode, T>
{
    public abstract class StateBase
    {
        protected StateMachine<TStateCode, T> stateMachine;

        public abstract void Tick();
        public abstract void FixedTick();

        public virtual void OnStateEnter() { }
        public virtual void OnStateExit() { }

        protected T Owner { get { return stateMachine.Owner; } }

        public StateBase(StateMachine<TStateCode, T> stateMachine)
        {
            this.stateMachine = stateMachine;
        }
    }

    private StateBase currentState;
    public StateBase CurrentState { get => currentState; }
    
    private Dictionary<TStateCode, StateBase> states;
    private TStateCode previousStateCode;
    private TStateCode currentStateCode;
    private TStateCode nextStateCode;

    public T Owner { get; private set; }

    private SimplePriorityQueue<TStateCode, int> statesQueue;
    
    public StateMachine(T owner)
    {
        Owner = owner;
        statesQueue = new SimplePriorityQueue<TStateCode, int>();
        states = new Dictionary<TStateCode, StateBase>();
    }

    private void SetState(StateBase state)
    {
        if (currentState != null)
        {
            previousStateCode = currentStateCode;
            currentState.OnStateExit();
        }

        Debug.Log("Current State: " + state);
        currentState = state;

        if (currentState != null)
        {
            currentStateCode = nextStateCode;
            currentState.OnStateEnter();
        }
    }

    private void ChangeToNextState()
    {
        if (statesQueue.Count > 0)
        {
            if (statesQueue.TryDequeue(out TStateCode stateCode))
            {
                if (states.TryGetValue(stateCode, out StateBase state))
                {
                    SetState(state);
                }
            }

            statesQueue.Clear();
        }
    }

    public void ChangeState(TStateCode stateCode, int priority = 0)
    {
        statesQueue.Enqueue(stateCode, priority);
    }

    public void AddState(TStateCode stateCode, StateBase state)
    {
        if (state != null)
        {
            states.Add(stateCode, state);
        }
    }

    public void Tick()
    {
        ChangeToNextState();

        if (currentState != null)
            currentState.Tick();
    }

    public void FixedTick()
    {
        ChangeToNextState();

        if (currentState != null)
            currentState.FixedTick();
    }
}
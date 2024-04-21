using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine.State;
using Zappar;
using PlazAR.View;

namespace FiniteStateMachine.Machine
{
    // handles
    [Serializable]
    public class StateMachine
    {
        public IState CurrentState { get; private set; }
        public EntryState entryState { get; private set; }
        public FallState fallState { get; private set; }
        public GetUpState getUpState { get; private set; }
        public ShakeState shakeState { get; private set; }
        public HoverState hoverState { get; private set; }

        // event to notify other objects of the state change
        public event Action<IState> stateChanged;

        // pass in necessary parameters into constructor 
        public StateMachine(ZapparInstantTrackingTarget zapparInstantTrackingTarget, CubeView cubeView)
        {
            // create an instance for each state and pass in PlayerController
            entryState = new EntryState(zapparInstantTrackingTarget, cubeView);
            fallState = new FallState(cubeView);
            getUpState = new GetUpState(cubeView);
            shakeState = new ShakeState(cubeView);
            hoverState = new HoverState(cubeView);

            Initialize(entryState);
        }

        // set the starting state
        private void Initialize(IState state)    
        {
            CurrentState = state;
            state.Enter();

            // notify other objects that state has changed
            stateChanged?.Invoke(state);
        }

        // exit this state and enter another
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();

            // notify other objects that state has changed
            stateChanged?.Invoke(nextState);
        }

        // allow the StateMachine to update this state
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}
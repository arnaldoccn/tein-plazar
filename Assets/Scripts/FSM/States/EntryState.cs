using System.Collections;
using System.Collections.Generic;
using PlazAR.View;
using UnityEngine;
using Zappar;

namespace FiniteStateMachine.State
{
    public class EntryState : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/
        private CubeView cubeView;
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;

        // pass in any parameters you need in the constructors
        public EntryState(ZapparInstantTrackingTarget zapparInstantTrackingTarget, CubeView cubeView)
        {
            this.zapparInstantTrackingTarget = zapparInstantTrackingTarget;
            this.cubeView = cubeView;
        }

        public void Enter()
        {
            // code that runs when we first enter the state
            Debug.Log("Entering Entry State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
            if (zapparInstantTrackingTarget.UserHasPlaced)
            {
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.fallState);
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                 cubeView.stateMachine.TransitionTo(cubeView.stateMachine.fallState);
            }

            // if we're no longer grounded, transition to jumping
           /* if (!player.IsGrounded)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.jumpState);
            }

            // if we move above a minimum threshold, transition to walking
            if (Mathf.Abs(player.CharController.velocity.x) > 0.1f || Mathf.Abs(player.CharController.velocity.z) > 0.1f)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.walkState);
            }*/
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Entry State");
        }
    }
}
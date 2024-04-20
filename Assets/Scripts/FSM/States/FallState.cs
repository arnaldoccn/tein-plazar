using System.Collections;
using System.Collections.Generic;
using PlazAR.View;
using Unity.VisualScripting;
using UnityEngine;

namespace FiniteStateMachine.State
{
    public class FallState : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/

        private CubeView cubeView;

        // pass in any parameters you need in the constructors
        public FallState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Entrada");
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
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
            Debug.Log("Exiting Fall State");
        }
    }
}
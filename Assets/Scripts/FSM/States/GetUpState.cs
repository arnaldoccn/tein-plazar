using System.Collections;
using System.Collections.Generic;
using PlazAR.View;
using Unity.VisualScripting;
using UnityEngine;

namespace FiniteStateMachine.State
{
    public class GetUpState : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/

        private CubeView cubeView;

        private bool isPlaying = false;

        // pass in any parameters you need in the constructors
        public GetUpState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Levita");
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {

            if (isPlaying && !cubeView.animationController.isPlaying)
             {
                // Animation finished playing
                Debug.Log("Animation finished");
                isPlaying = false;
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.hoverState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
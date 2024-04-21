using System.Collections;
using System.Collections.Generic;
using PlazAR.View;
using Unity.VisualScripting;
using UnityEngine;

namespace FiniteStateMachine.State
{
    public class HoverState : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/

        private CubeView cubeView;

        private bool isPlaying = false;

        private int count = 0;

        private int maxCount = 1000;

        // pass in any parameters you need in the constructors
        public HoverState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Hover_Simples");
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
            count++;
            if (count >= maxCount)
            {
                count = 0;
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.shakeState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
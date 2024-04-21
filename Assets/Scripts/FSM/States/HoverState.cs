using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

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

        private int maxCount = 250;

        // pass in any parameters you need in the constructors
        public HoverState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Hover_Simples");
            SwipeDetector.OnSwipeRight += HandleSwipeRight;
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

        void HandleSwipeRight()
        {
            cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountOneState);
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
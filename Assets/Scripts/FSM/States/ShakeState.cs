using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class ShakeState : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/

        private CubeView cubeView;

        private bool isPlaying = false;

        // pass in any parameters you need in the constructors
        public ShakeState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Tremilique");
            SwipeDetector.OnSwipeRight += HandleSwipeRight;
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        void HandleSwipeRight()
        {
            SwipeDetector.OnSwipeRight -= HandleSwipeRight;
            cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountOneState);
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
            if (isPlaying && !cubeView.animationController.isPlaying)
             {
                // Animation finished playing
                Debug.Log("Animation finished");
                SwipeDetector.OnSwipeRight -= HandleSwipeRight;
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
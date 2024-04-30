using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class MountOne : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/

        private CubeView cubeView;

        private bool isPlaying = false;

        // pass in any parameters you need in the constructors
        public MountOne(CubeView cubeView)
        {
            this.cubeView = cubeView;
            SwipeDetector.OnSwipeUp += HandleSwipeUp;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Montagem_1");
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        void HandleSwipeUp()
        {
            SwipeDetector.OnSwipeUp -= HandleSwipeUp;
            cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountTwoState);
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                 cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountTwoState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
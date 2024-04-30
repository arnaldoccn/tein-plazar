using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class MountTwo : IState
    {

        /*private PlayerController player;

        // color to change player (alternately: pass in color value with constructor)
        private Color meshColor = Color.gray;
        public Color MeshColor { get => meshColor; set => meshColor = value; }*/

        private CubeView cubeView;

        private bool isPlaying = false;

        // pass in any parameters you need in the constructors
        public MountTwo(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Montagem_2");
            isPlaying = true;
            SwipeDetector.OnSwipeUp += HandleSwipeUp;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        void HandleSwipeUp()
        {
            SwipeDetector.OnSwipeUp -= HandleSwipeUp;
            cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountThreeState);
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                 cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountThreeState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
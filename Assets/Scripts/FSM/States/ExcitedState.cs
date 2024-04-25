using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class ExcitedState : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;
        public ExcitedState(CubeView cubeView)
        {
            this.cubeView = cubeView;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Excited");
            isPlaying = true;
        }

        public void Update()
        {
            if (isPlaying && !cubeView.animationController.isPlaying)
             {
                // Animation finished playing
                Debug.Log("Animation finished");
                isPlaying = false;
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.presentationState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
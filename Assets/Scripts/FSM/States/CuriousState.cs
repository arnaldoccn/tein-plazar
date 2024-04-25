using PlazAR.View;
using UnityEngine;

namespace FiniteStateMachine.State
{
    public class CuriousState : IState
    {

        private CubeView cubeView;

        private bool isPlaying = false;

        // pass in any parameters you need in the constructors
        public CuriousState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Curious");
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        public void Update()
        {
            if (isPlaying && !cubeView.animationController.isPlaying)
             {
                // Animation finished playing
                Debug.Log("Animation finished");
                isPlaying = false;
                //cubeView.stateMachine.TransitionTo(cubeView.stateMachine.explodeState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
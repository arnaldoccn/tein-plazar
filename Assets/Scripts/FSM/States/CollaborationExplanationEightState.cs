using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class CollaborationExplanationEightState : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;

        public CollaborationExplanationEightState(CubeView cubeView)
        {
            this.cubeView = cubeView;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Talk_Loop_2");
            cubeView.PlayNextTalkAudio();
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
            if(!cubeView.audioSource.isPlaying)
             {
                // Animation finished playing
                Debug.Log("Audio finished");
                isPlaying = false;
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.curiousState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
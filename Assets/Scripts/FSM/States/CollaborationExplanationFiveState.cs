using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class CollaborationExplanationSixState : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;
        private bool alreadyPlayed = false;

        public CollaborationExplanationSixState(CubeView cubeView)
        {
            this.cubeView = cubeView;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Talk");
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
               cubeView.stateMachine.TransitionTo(cubeView.stateMachine.collaborationExplanationSixState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
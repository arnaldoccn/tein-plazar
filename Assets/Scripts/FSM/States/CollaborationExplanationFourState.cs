using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class CollaborationExplanationFourState : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;

        private bool alreadyPlayed = false;

        public CollaborationExplanationFourState(CubeView cubeView)
        {
            this.cubeView = cubeView;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Chacoalha");
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
                alreadyPlayed = true;
                cubeView.PlayAnimation("Talk");
                cubeView.PlayNextTalkAudio();
            }

            if(!cubeView.audioSource.isPlaying && alreadyPlayed)
             {
                // Animation finished playing
                Debug.Log("Audio finished");
                isPlaying = false;
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.collaborationExplanationFiveState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
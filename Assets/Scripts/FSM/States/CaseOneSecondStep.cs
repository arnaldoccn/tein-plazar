using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class CaseOneSecondStep : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;
        private bool alreadyPlayed = false;

        public CaseOneSecondStep(CubeView cubeView)
        {
            this.cubeView = cubeView;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Excited");
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
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.caseOneThirdStep);
            }
        }


        public void Exit()
        {
            alreadyPlayed = false;
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
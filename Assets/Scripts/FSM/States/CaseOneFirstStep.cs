using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class CaseOneFirstStep : IState
    {
        private CubeView cubeView;
        public CaseOneFirstStep(CubeView cubeView)
        {
            this.cubeView = cubeView;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Talk");
            cubeView.PlayNextTalkAudio();
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
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.caseOneSecondStep);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
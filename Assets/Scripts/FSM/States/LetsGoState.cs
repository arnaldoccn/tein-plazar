using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;

namespace FiniteStateMachine.State
{
    public class LetsGoState : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;
        public LetsGoState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            cubeView.OnLetsGoClickedEvent += HandleLetsGoClickedEvent;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Idle_Hover");
            cubeView.PlayNextTalkAudio();
            isPlaying = true;
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }

        private void HandleLetsGoClickedEvent()
        {
            cubeView.stateMachine.TransitionTo(cubeView.stateMachine.collaborationIntroState);
        }
    }
}
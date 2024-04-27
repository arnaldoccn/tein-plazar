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
            cubeView.PlayAnimation("Chacoalha");
            cubeView.PlayQueue("Idle_Hover");
            isPlaying = true;
            // code that runs when we first enter the state
            Debug.Log("Entering Fall State");
            cubeView.ShowMenu();
        }


        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
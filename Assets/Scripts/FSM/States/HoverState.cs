using PlazAR.View;
using UnityEngine;
using PlazAR.Tools;
using System;
using System.Collections;

namespace FiniteStateMachine.State
{
    public class HoverState : IState
    {
        private CubeView cubeView;

        private bool isPlaying = false;

        private int count = 0;

        private int maxCount = 250;

        private float delayInSeconds = 2;

        public HoverState(CubeView cubeView)
        {
            this.cubeView = cubeView;
            //this.player = player;
        }

        public void Enter()
        {   
            cubeView.PlayAnimation("Hover_Simples");
            SwipeDetector.OnSwipeDown += HandleSwipeDown;
            isPlaying = true;
            CoroutineHandler.Instance.StartCoroutineOnHandler(ExecuteDelayedCoroutine(delayInSeconds, () => {cubeView.stateMachine.TransitionTo(cubeView.stateMachine.shakeState);}));
            Debug.Log("Entering Fall State");
        }

        /*public void Update()
        {
            count++;
            if (count >= maxCount)
            {
                count = 0;
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.shakeState);
            }
        }*/

        private static IEnumerator ExecuteDelayedCoroutine(float delayInSeconds, Action action)
        {
            yield return new WaitForSeconds(delayInSeconds);
            action?.Invoke();
        }

        void HandleSwipeDown()
        {
            CoroutineHandler.Instance.StopCoroutines();
            SwipeDetector.OnSwipeDown -= HandleSwipeDown;
            cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountOneState);
        }

        public void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                CoroutineHandler.Instance.StopCoroutines();
                cubeView.stateMachine.TransitionTo(cubeView.stateMachine.mountOneState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            Debug.Log("Exiting Fall State");
        }
    }
}
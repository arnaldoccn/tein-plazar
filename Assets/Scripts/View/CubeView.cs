using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using TMPro;
using FiniteStateMachine.Machine;

namespace PlazAR.View
{
    [RequireComponent(typeof(Animation))]
    public class CubeView : MonoBehaviour, ICubeView
    {
        public StateMachine stateMachine;
        public Animation animationController { get; private set; }
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;
        
        void Awake()
        {
            animationController = GetComponent<Animation>();
        }

        public void PlayAnimation(string name)
        {
            animationController.CrossFade(name);
        }

        void Update()
        {
            stateMachine.Update();
        }

        public void SetZapparInstantTrackingTarget(ZapparInstantTrackingTarget zapparInstantTrackingTarget)
        {
            stateMachine = new StateMachine(zapparInstantTrackingTarget, this);
        }
    }
}


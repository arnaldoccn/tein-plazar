using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using TMPro;
using FiniteStateMachine.Machine;

namespace PlazAR.View
{
    [RequireComponent(typeof(Animation))]
    [RequireComponent(typeof(AudioSource))]
    public class CubeView : MonoBehaviour, ICubeView
    {
        [SerializeField]
        private List<AudioClip> talkAudios = new();
        public StateMachine stateMachine;
        public Animation animationController { get; private set; }
        public AudioSource audioSource { get; private set; }
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;

        public delegate void LetsGoClickedEventHandler();
        public event LetsGoClickedEventHandler OnLetsGoClickedEvent;

        public delegate void PresentationExitEventHandler();
        public event PresentationExitEventHandler OnPresentationExitEventHandler;
        
        private int talkAudioIndex = 0;

        void Awake()
        {
            animationController = GetComponent<Animation>();
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayAnimation(string name)
        {
            animationController.CrossFade(name);
        }

        public void PlayNextTalkAudio()
        {
            audioSource.PlayOneShot(talkAudios[talkAudioIndex]);
            talkAudioIndex++;
        }

        void Update()
        {
            stateMachine?.Update();
        }

        public void SetZapparInstantTrackingTarget(ZapparInstantTrackingTarget zapparInstantTrackingTarget)
        {
            stateMachine = new StateMachine(zapparInstantTrackingTarget, this);
            stateMachine.OnPresentationExitEventHandler += HandlePresentationExit;
        }

        private void HandlePresentationExit()
        {
            OnPresentationExitEventHandler();
        }

        public void LetsGoClicked()
        {
            OnLetsGoClickedEvent();
        }
    }
}
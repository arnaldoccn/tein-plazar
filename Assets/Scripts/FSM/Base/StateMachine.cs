using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FiniteStateMachine.State;
using Zappar;
using PlazAR.View;

namespace FiniteStateMachine.Machine
{
    // handles
    [Serializable]
    public class StateMachine
    {

        public delegate void PresentationExitEventHandler();
        public event PresentationExitEventHandler OnPresentationExitEventHandler;

        public IState CurrentState { get; private set; }
        public EntryState entryState { get; private set; }
        public FallState fallState { get; private set; }
        public GetUpState getUpState { get; private set; }
        public ShakeState shakeState { get; private set; }
        public HoverState hoverState { get; private set; }
        public MountOne mountOneState { get; private set; }
        public MountTwo mountTwoState { get; private set; }
        public MountThree mountThreeState { get; private set; }
        public WakeUpState wakeUpState { get; private set; }
        public ExplodeState explodeState { get; private set; }
        public ShakeTwoState shakeTwoState { get; private set; }
        public HiState hiState { get; private set; }
        public ExcitedState excitedState { get; private set; }
        public PresentationState presentationState { get; private set; }
        public LetsGoState letsGoState { get; private set; }
        public CuriousState curiousState { get; private set; }

        public CollaborationIntroState collaborationIntroState { get; private set; }
        public CollaborationExplanationOneState collaborationExplanationOneState { get; private set; }
        public CollaborationExplanationTwoState collaborationExplanationTwoState { get; private set; }
        public CollaborationExplanationThreeState collaborationExplanationThreeState { get; private set; }
        public CollaborationExplanationFourState collaborationExplanationFourState { get; private set; }
        public CollaborationExplanationFiveState collaborationExplanationFiveState { get; private set; }
        public CollaborationExplanationSixState collaborationExplanationSixState { get; private set; }
        public CollaborationExplanationSevenState collaborationExplanationSevenState { get; private set; }
        public CollaborationExplanationEightState collaborationExplanationEightState { get; private set; }

        public CaseOneFirstStep caseOneFirstStep { get; private set; }
        public CaseOneSecondStep caseOneSecondStep { get; private set; }
        public CaseOneThirdStep caseOneThirdStep { get; private set; }
        public CaseOneFourthStep caseOneFourthStep { get; private set; }
        public CaseOneFifthStep caseOneFifthStep { get; private set; }
        public CaseOneSixthStep caseOneSixthStep { get; private set; }
        public CaseOneSeventhStep caseOneSeventhStep { get; private set; }

        // event to notify other objects of the state change
        public event Action<IState> stateChanged;

        // pass in necessary parameters into constructor 
        public StateMachine(ZapparInstantTrackingTarget zapparInstantTrackingTarget, CubeView cubeView)
        {
            // create an instance for each state and pass in PlayerController
            entryState = new EntryState(zapparInstantTrackingTarget, cubeView);
            fallState = new FallState(cubeView);
            getUpState = new GetUpState(cubeView);
            shakeState = new ShakeState(cubeView);
            hoverState = new HoverState(cubeView);
            mountOneState = new MountOne(cubeView);
            mountTwoState = new MountTwo(cubeView);
            mountThreeState = new MountThree(cubeView);
            wakeUpState = new WakeUpState(cubeView);
            explodeState = new ExplodeState(cubeView);
            shakeTwoState = new ShakeTwoState(cubeView);
            hiState = new HiState(cubeView);
            excitedState = new ExcitedState(cubeView);
            presentationState = new PresentationState(cubeView);
            letsGoState = new LetsGoState(cubeView);
            curiousState = new CuriousState(cubeView);

            collaborationIntroState = new CollaborationIntroState(cubeView);
            collaborationExplanationOneState = new CollaborationExplanationOneState(cubeView);
            collaborationExplanationTwoState = new CollaborationExplanationTwoState(cubeView);
            collaborationExplanationThreeState = new CollaborationExplanationThreeState(cubeView);
            collaborationExplanationFourState = new CollaborationExplanationFourState(cubeView);
            collaborationExplanationFiveState = new CollaborationExplanationFiveState(cubeView);
            collaborationExplanationSixState = new CollaborationExplanationSixState(cubeView);
            collaborationExplanationSevenState = new CollaborationExplanationSevenState(cubeView);
            collaborationExplanationEightState = new CollaborationExplanationEightState(cubeView);

            caseOneFirstStep = new CaseOneFirstStep(cubeView);
            caseOneSecondStep = new CaseOneSecondStep(cubeView);
            caseOneThirdStep = new CaseOneThirdStep(cubeView);
            caseOneFourthStep = new CaseOneFourthStep(cubeView);
            caseOneFifthStep = new CaseOneFifthStep(cubeView);
            caseOneSixthStep = new CaseOneSixthStep(cubeView);
            caseOneSeventhStep = new CaseOneSeventhStep(cubeView);

            presentationState.OnPresentationExitEventHandler += HandlePresentationExitEvent;

            Initialize(entryState);
        }

        private void HandlePresentationExitEvent()
        {
            OnPresentationExitEventHandler();
        }

        // set the starting state
        private void Initialize(IState state)    
        {
            CurrentState = state;
            state.Enter();

            // notify other objects that state has changed
            stateChanged?.Invoke(state);
        }

        // exit this state and enter another
        public void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();

            // notify other objects that state has changed
            stateChanged?.Invoke(nextState);
        }

        // allow the StateMachine to update this state
        public void Update()
        {
            if (CurrentState != null)
            {
                CurrentState.Update();
            }
        }
    }
}
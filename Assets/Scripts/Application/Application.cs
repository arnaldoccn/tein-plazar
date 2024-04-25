using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zappar;
using PlazAR.View;
using PlazAR.Model;
using PlazAR.Presenter;
using UnityCommunity.UnitySingleton;

namespace PlazAR.Application
{
    public class Application : PersistentMonoSingleton<Application>
    {
        [SerializeField]
        private HUDView hudView;
        [SerializeField]
        private CubeView cubeView;
        [SerializeField]
        private ZapparInstantTrackingTarget zapparInstantTrackingTarget;

        private CubePresenter cubePresenter;
        private HUDPresenter hudPresenter;

        void Awake()
        {
            cubePresenter = new CubePresenter(new CubeModel(), cubeView, zapparInstantTrackingTarget);
            cubePresenter.OnPresentationExitEventHandler += HandlePresentationExit;
            hudPresenter = new HUDPresenter(new HUDModel(), hudView);
            hudPresenter.OnLetsGoClickedEvent += HandleOnLetsGoClickedEvent;
        }
        
        private void HandleOnLetsGoClickedEvent()
        {
            cubePresenter.LetsGoClicked();
        }

        private void HandlePresentationExit()
        {
            hudPresenter.ShowLetsGoButton();
        }
    }
}
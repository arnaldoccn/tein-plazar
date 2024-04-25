using UnityEngine;
using Zappar;
using PlazAR.View;
using PlazAR.Model;

namespace PlazAR.Presenter
{
    public class CubePresenter
    {
        private CubeModel cubeModel;
        private CubeView cubeView;

        public delegate void PresentationExitEventHandler();
        public event PresentationExitEventHandler OnPresentationExitEventHandler;

        public CubePresenter(CubeModel cubeModel, CubeView cubeView, ZapparInstantTrackingTarget zapparInstantTrackingTarget)
        {
            this.cubeModel = cubeModel;
            this.cubeView = cubeView;
            cubeView.SetZapparInstantTrackingTarget(zapparInstantTrackingTarget);
            cubeView.OnPresentationExitEventHandler += HandlePresentationExit;
        }
        
        public void LetsGoClicked()
        {
            cubeView.LetsGoClicked();
        }

        private void HandlePresentationExit()
        {
            OnPresentationExitEventHandler();
        }

    }
}
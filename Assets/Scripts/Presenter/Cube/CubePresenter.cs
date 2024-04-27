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
        public delegate void ShowMenuEvent();
        public event ShowMenuEvent OnShowMenu;
        public CubePresenter(CubeModel cubeModel, CubeView cubeView, ZapparInstantTrackingTarget zapparInstantTrackingTarget)
        {
            this.cubeModel = cubeModel;
            this.cubeView = cubeView;
            cubeView.SetZapparInstantTrackingTarget(zapparInstantTrackingTarget);
            cubeView.OnPresentationExitEventHandler += HandlePresentationExit;
            cubeView.OnShowMenu += HandleShowMenu;

        }
        
        public void LetsGoClicked()
        {
            cubeView.LetsGoClicked();
        }

        public void CollaborationClicked()
        {
            cubeView.CollaborationClicked();
        }

        private void HandlePresentationExit()
        {
            OnPresentationExitEventHandler();
        }

        private void HandleShowMenu()
        {
            OnShowMenu();
        }

    }
}
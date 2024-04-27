using UnityEngine;
using PlazAR.View;
using PlazAR.Model;

namespace PlazAR.Presenter
{
    public class HUDPresenter
    {
        private HUDModel hudModel;
        private HUDView hudView;
        public delegate void LetsGoClickedEventHandler();
        public event LetsGoClickedEventHandler OnLetsGoClickedEvent;
        public delegate void CollaborationClickedEventHandler();
        public event CollaborationClickedEventHandler OnCollaborationClickedEvent;

        public HUDPresenter(HUDModel hudModel, HUDView hudView)
        {
            this.hudModel = hudModel;
            this.hudView = hudView;
            this.hudView.OnLetsGoClickedEvent += HandleLetsGoClickedEvent;
            this.hudView.OnCollaborationClickedEvent += HandleCollaborationClickedEvent;
        }

        private void HandleLetsGoClickedEvent()
        {
            OnLetsGoClickedEvent();
        }

        private void HandleCollaborationClickedEvent()
        {
            OnCollaborationClickedEvent();
        }

        public void ShowLetsGoButton()
        {
            hudView.ShowLetsGoButton();
        }

        public void ShowMenu()
        {
            hudView.ShowMenu();
        }
    }
}
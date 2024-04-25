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

        public HUDPresenter(HUDModel hudModel, HUDView hudView)
        {
            this.hudModel = hudModel;
            this.hudView = hudView;
            this.hudView.OnLetsGoClickedEvent += HandleLetsGoClickedEvent;
        }

        private void HandleLetsGoClickedEvent()
        {
            OnLetsGoClickedEvent();
        }

        public void ShowLetsGoButton()
        {
            hudView.ShowLetsGoButton();
        }
    }
}
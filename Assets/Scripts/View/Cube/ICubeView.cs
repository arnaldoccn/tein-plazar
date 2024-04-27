namespace PlazAR.View
{
    public interface ICubeView
    {
        void PlayAnimation(string name);
        void PlayQueue(string name);
        void PlayNextTalkAudio();
        void LetsGoClicked();
        void ShowMenu();
    }
}
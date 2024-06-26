using UnityEngine;

namespace PlazAR.View
{
    public interface ICubeView
    {
        void PlayAnimation(string name);
        void PlayQueue(string name);
        void PlayNextTalkAudio();
        void LetsGoClicked();
        void ShowMenu();
        void SetCubeIndexTalkToMenu();

        void PlaySFX(AudioClip audioClip);
        void PlayHover();
        void StopHover();
    }
}
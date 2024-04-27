using PlazAR.View;
using UnityEngine;
using UnityEngine.UI;
using PlazAR.Tools;

public class HUDView : MonoBehaviour, IHUDView
{
    [SerializeField]
    private UIFadeManager uiFadeManager;
    [SerializeField]
    private Button letsGoButton;
    [SerializeField]
    private Button collaborationButton;

    public delegate void LetsGoClickedEventHandler();
    public event LetsGoClickedEventHandler OnLetsGoClickedEvent;

    public delegate void CollaborationClickedEventHandler();
    public event CollaborationClickedEventHandler OnCollaborationClickedEvent;

    private void OnLetsGoClicked()
    {
        letsGoButton.gameObject.SetActive(false);
        OnLetsGoClickedEvent();
    }

    public void     ShowMenu()
    {
        uiFadeManager.ExecuteFade(UIFadeManager.FadeType.FadeIn);
        collaborationButton.interactable = true;
        collaborationButton.onClick.AddListener(OnCollaborationClicked);
    }

    public void ShowLetsGoButton()
    {
        letsGoButton.gameObject.SetActive(true);
        letsGoButton.onClick.AddListener(OnLetsGoClicked);
    }

    private void OnCollaborationClicked()
    {
        collaborationButton.onClick.RemoveAllListeners();
        collaborationButton.interactable = false;
        uiFadeManager.ExecuteFade(UIFadeManager.FadeType.FadeOut);
        OnCollaborationClickedEvent();
    }
}
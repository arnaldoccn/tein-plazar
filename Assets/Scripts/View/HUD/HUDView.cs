using PlazAR.View;
using UnityEngine;
using UnityEngine.UI;

public class HUDView : MonoBehaviour, IHUDView
{
    [SerializeField]
    private Button letsGoButton;

    public delegate void LetsGoClickedEventHandler();
    public event LetsGoClickedEventHandler OnLetsGoClickedEvent;

    private void OnLetsGoClicked()
    {
        letsGoButton.gameObject.SetActive(false);
        OnLetsGoClickedEvent();
    }

    public void ShowLetsGoButton()
    {
        letsGoButton.gameObject.SetActive(true);
        letsGoButton.onClick.AddListener(OnLetsGoClicked);
    }
}
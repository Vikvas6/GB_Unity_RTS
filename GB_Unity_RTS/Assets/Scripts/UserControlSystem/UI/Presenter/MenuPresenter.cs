using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Zenject;

public class MenuPresenter : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _exitButton;
    [Inject] private ITimeModel _timeModel;

    private void Start()
    {
        _backButton.OnClickAsObservable().Subscribe(_ => HandleBackButton());
        _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
    }

    private void HandleBackButton()
    {
        gameObject.SetActive(false);
        _timeModel.UnPause();
    }
}
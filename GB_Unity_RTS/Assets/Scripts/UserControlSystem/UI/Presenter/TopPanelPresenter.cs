using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UniRx;
using System;

public class TopPanelPresenter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuGo;
    private ITimeModel _timeModel;

    [Inject]
    private void Init(ITimeModel timeModel)
    {
        _timeModel = timeModel;
        _timeModel.GameTime.Subscribe(seconds =>
        {
            var t = TimeSpan.FromSeconds(seconds);
            _inputField.text = string.Format("{0:D2}:{1:D2}",
                t.Minutes,
                t.Seconds);
        });

        _menuButton.OnClickAsObservable().Subscribe(_ => HandleMenuButtonClick());
    }

    private void HandleMenuButtonClick()
    {
        _menuGo.gameObject.SetActive(true);
        _timeModel.Pause();
    }
}
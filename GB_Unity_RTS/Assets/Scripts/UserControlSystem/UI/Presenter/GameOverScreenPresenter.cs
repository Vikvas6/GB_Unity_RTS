using TMPro;
using UnityEngine;
using UniRx;
using Zenject;


public class GameOverScreenPresenter : MonoBehaviour
{
    [Inject] private IGameOver _gameOver;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private GameObject _view;
    
    private void Start()
    {
        _gameOver.FactionWon.ObserveOnMainThread().Subscribe(onGameEnd);
    }

    private void onGameEnd(int factionWon)
    {
        _text.text = factionWon == -1 ? "DRAW" : $"Faction {factionWon} won!";
        _view.SetActive(true);
        Time.timeScale = 0;
    }
}

using System;
using UniRx;
using UnityEngine;
using Zenject;

public class TimeModel : ITimeModel, ITickable
{
    public IObservable<int> GameTime => _gameTime.Select(f => (int)f);
    private ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();
    //private bool _isPaused;

    public void Tick()
    {
        _gameTime.Value += Time.deltaTime;
    }

    public void Pause()
    {
        //_isPaused = true;
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        //_isPaused = false;
        Time.timeScale = 1;
    }
}
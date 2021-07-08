using System;

public interface ITimeModel
{
    IObservable<int> GameTime { get; }
    void Pause();
    void UnPause();
}
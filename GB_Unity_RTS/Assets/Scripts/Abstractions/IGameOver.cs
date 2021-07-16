using System;


public interface IGameOver
{
    IObservable<int> FactionWon { get; }
}

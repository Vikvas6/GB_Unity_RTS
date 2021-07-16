using System;
using System.Threading;
using UniRx;
using UnityEngine;


public class GameOverController : MonoBehaviour, IGameOver
{
    private Subject<int> _factionWon = new Subject<int>();

    public IObservable<int> FactionWon => _factionWon;

    private void Update()
    {
        ThreadPool.QueueUserWorkItem(checkEndCondition);
    }

    private void checkEndCondition(object _)
    {
        if (FactionMember.GetAliveFactionsCount() <= 1)
        {
            _factionWon.OnNext(FactionMember.GetFirstFaction());
        }
    }
}

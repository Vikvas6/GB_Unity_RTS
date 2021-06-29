using System.Collections.Generic;
using UnityEngine;


public interface IProduceUnitCommand : ICommand
{
    GameObject UnitPrefab { get; }
}

public interface IAttackCommand : ICommand
{
    public IAttackable Target { get; }
}

public interface IMoveCommand : ICommand
{
    public Vector3 Target { get; }
}

public interface IPatrolCommand : ICommand
{
    public Vector3 From { get; }
    public Vector3 To { get; }
}

public interface IStopCommand : ICommand
{
}
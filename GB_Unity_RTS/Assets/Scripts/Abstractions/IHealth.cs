using System;

public interface IHealth
{
    IObservable<float> Health { get; }
    float MaxHealth { get; }
}

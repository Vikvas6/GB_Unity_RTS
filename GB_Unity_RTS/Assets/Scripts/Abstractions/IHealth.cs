using System;

public interface IHealth
{
    IObservable<float> Health { get; }
    float HealthFloat { get; }
    float MaxHealth { get; }
}

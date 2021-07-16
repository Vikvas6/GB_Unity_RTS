using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;


public class MainBuilding : MonoBehaviour, ISelectable, IAttackable, IObstacle
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private float _health;
    
    public Vector3 Destination { get; set; }
    
    public Sprite Icon => _icon;
    public IObservable<float> Health => _reactiveHealth;
    public float HealthFloat => _reactiveHealth.Value;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => gameObject.transform;
    
    private ReactiveProperty<float> _reactiveHealth;

    public void Start()
    {
        _reactiveHealth = new ReactiveProperty<float>(_health);
        Destination = gameObject.transform.position + gameObject.transform.forward * 4;
    }

    public void RecieveDamage(int amount)
    {
        if (_reactiveHealth.Value <= 0)
        {
            return;
        }
        _reactiveHealth.Value -= amount;
        if (_reactiveHealth.Value <= 0)
        {
            Destroy(gameObject);
        }
    }
}

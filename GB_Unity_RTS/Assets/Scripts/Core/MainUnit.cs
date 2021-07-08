using System;
using UniRx;
using UnityEngine;


public class MainUnit : MonoBehaviour, ISelectable, IAttackable
{
    public IObservable<float> Health => _reactiveHealth;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => gameObject.transform;
    
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;
    private float _health = 50;
    
    private ReactiveProperty<float> _reactiveHealth;

    public void Start()
    {
        _reactiveHealth = new ReactiveProperty<float>(_health);
    }

    private void Update()
    {
        _reactiveHealth.Value -= Time.deltaTime * 5;
    }
}

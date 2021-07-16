using System;
using UniRx;
using UnityEngine;


public class MainUnit : MonoBehaviour, ISelectable, IAttackable, IObstacle, IDamageDealer
{
    public IObservable<float> Health => _reactiveHealth;
    public float HealthFloat => _reactiveHealth.Value;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => gameObject.transform;
    
    [SerializeField] private float _maxHealth = 50;
    [SerializeField] private Sprite _icon;
    [SerializeField] private Animator _animator;
    [SerializeField] private StopCommandExecutor _stopCommand;
    
    private float _health = 50;
    
    private ReactiveProperty<float> _reactiveHealth;
    
    public int Damage => _damage;
    [SerializeField] private int _damage = 25;

    public void Start()
    {
        _reactiveHealth = new ReactiveProperty<float>(_health);
    }
    
    public void RecieveDamage(int amount)
    {
        if (_health <= 0)
        {
            return;
        }
        _reactiveHealth.Value -= amount;
        if (_reactiveHealth.Value <= 0)
        {
            _animator.SetTrigger("PlayDead");
            Invoke(nameof(destroy), 1f);
        }
    }
    
    private async void destroy()
    {
        await _stopCommand.ExecuteSpecificCommand(new StopCommand());
        Destroy(gameObject);
    }
}

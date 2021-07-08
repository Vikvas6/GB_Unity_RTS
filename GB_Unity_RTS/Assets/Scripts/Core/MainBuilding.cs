using System;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;


public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
{
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private float _health;
    [SerializeField] private Transform _unitsParent;
    
    public Sprite Icon => _icon;
    public IObservable<float> Health => _reactiveHealth;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => gameObject.transform;

    private MeshRenderer[] _childMeshs;
    
    private ReactiveProperty<float> _reactiveHealth;

    public void Start()
    {
        _childMeshs = gameObject.GetComponentsInChildren<MeshRenderer>();
        _reactiveHealth = new ReactiveProperty<float>(_health);
    }

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity,
            _unitsParent);
    }

}

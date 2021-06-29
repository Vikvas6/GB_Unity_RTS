using UnityEngine;
using Random = UnityEngine.Random;


public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable, IAttackable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;
    public Transform PivotPoint => gameObject.transform;

    [SerializeField] private Transform _unitsParent;
    
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private MeshRenderer[] _childMeshs;
    private float _health = 1000;

    public void Start()
    {
        _childMeshs = gameObject.GetComponentsInChildren<MeshRenderer>();
    }

    public override void ExecuteSpecificCommand(IProduceUnitCommand command)
    {
        Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity,
            _unitsParent);
    }
}

using UnityEngine;
using Zenject;


public class GrenadierProduceUnitCommand : IProduceUnitCommand
{    
    [Inject(Id = "Grenadier")] public string UnitName { get; }
    [Inject(Id = "Grenadier")] public Sprite Icon { get; }
    [Inject(Id = "Grenadier")] public float ProductionTime { get; }

    public GameObject UnitPrefab => _unitPrefab;
    [InjectAsset("Grenadier")] private GameObject _unitPrefab;
}

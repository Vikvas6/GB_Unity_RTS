using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class MainBuilding : MonoBehaviour, IUnitProducer, ISelectable
{
    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    [SerializeField] private GameObject _unitPrefab;
    [SerializeField] private Transform _unitsParent;
    [SerializeField] private Material _outline;
    
    [SerializeField] private float _maxHealth = 1000;
    [SerializeField] private Sprite _icon;

    private MeshRenderer[] _childMeshs;
    private float _health = 1000;

    public void Start()
    {
        _childMeshs = gameObject.GetComponentsInChildren<MeshRenderer>();
    }


    public void ProduceUnit()
    {
        Instantiate(_unitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity,
            _unitsParent);
    }

    public void SelectObject()
    {
        foreach (var mesh in _childMeshs)
        {
            List<Material> materials = new List<Material>(mesh.materials);
            materials.Add(_outline);
            mesh.materials = materials.ToArray();
        }
    }

    public void UnSelectObject()
    {
        foreach (var mesh in _childMeshs)
        {
            List<Material> materials = new List<Material>(mesh.materials);
            if (materials.Count > 1)
            {
                materials.RemoveAt(1);
            }
            mesh.materials = materials.ToArray();
        }
    }
}

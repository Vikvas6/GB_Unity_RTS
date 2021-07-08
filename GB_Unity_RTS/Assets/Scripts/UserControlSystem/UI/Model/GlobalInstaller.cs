using System;
using UniRx;
using UnityEngine;
using Zenject;


[CreateAssetMenu(fileName = "GlobalInstaller", menuName = "Installers/GlobalInstaller")]
public class GlobalInstaller : ScriptableObjectInstaller<GlobalInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private Vector3Value _vector3Value;
    [SerializeField] private AttackableValue _attackableValue;
    [SerializeField] private SelectableValue _selectableValue;
    
    public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);
        Container.Bind<Vector3Value>().FromInstance(_vector3Value);
        Container.Bind<AttackableValue>().FromInstance(_attackableValue);
        Container.Bind<SelectableValue>().FromInstance(_selectableValue);

        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackableValue);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
    }
}
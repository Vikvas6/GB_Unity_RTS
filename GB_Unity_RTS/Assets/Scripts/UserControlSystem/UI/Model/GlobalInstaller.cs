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
    [SerializeField] private Sprite _chomperSprite;
    
    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _vector3Value, _attackableValue, _selectableValue);

        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_attackableValue);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        
        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_chomperSprite);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectableValue);
    }
}
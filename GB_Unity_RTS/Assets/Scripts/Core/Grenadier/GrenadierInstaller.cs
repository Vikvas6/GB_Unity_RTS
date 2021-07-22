using UnityEngine;
using Zenject;


public class GrenadierInstaller : MonoInstaller
{
    [SerializeField] private AttackerParallelnfoUpdater _attackerParallelnfoUpdater;
    [SerializeField] private FactionMemberParallelInfoUpdater _factionMemberParallelInfoUpdater;
    
    
    public override void InstallBindings()
    {
        Container.Bind<IHealth>().FromComponentInChildren();
        Container.Bind<float>().WithId("AttackDistance").FromInstance(15f);
        Container.Bind<int>().WithId("AttackPeriod").FromInstance(5000);

        Container.Bind<IAutomaticAttacker>().FromComponentInChildren();
        Container
            .Bind<ITickable>()
            .FromInstance(_attackerParallelnfoUpdater);
        Container
            .Bind<ITickable>()
            .FromInstance(_factionMemberParallelInfoUpdater);
        Container.Bind<IFactionMember>().FromComponentInChildren();
        Container.Bind<ICommandsQueue>().FromComponentInChildren();
    }
}

using UnityEngine;
using Zenject;


public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TimeModel>().AsSingle();
        Container.Bind<IGameOver>().FromInstance(GetComponent<GameOverController>());
    }
}
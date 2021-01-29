using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
#if UNITY_EDITOR
        Container
            .Bind<IInputProvider>()
            .To<UnityInputProvider>()
            .AsSingle();
#elif UNITY_ANDROID

#endif

        Container
            .Bind<IPlayerParametor>()
            .To<PlayerParametor>()
            .AsSingle();
    }
}
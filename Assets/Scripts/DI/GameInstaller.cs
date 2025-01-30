using Scripts.Entities.Animation;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IMoveAnimation>().To<MovementAnimation>().AsTransient();
    }
}

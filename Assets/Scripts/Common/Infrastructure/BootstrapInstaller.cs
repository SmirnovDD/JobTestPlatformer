using JobTest.Input;
using JobTest.Time;
using Zenject;

namespace JobTest.Common.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputController>().To<InputController>().AsSingle();
            Container.Bind<IGameTime>().To<GameTime>().AsSingle();
        }
    }
}
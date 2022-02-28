using OsuHitsound.Objects;
using Zenject;

namespace OsuHitsound.Installers
{
    class OhAppInstaller : Installer
    {
        private readonly Config _config;
        public OhAppInstaller(Config config)
        {
            _config = config;
        }
        public override void InstallBindings()
        {
            Container.BindInstance(_config).AsSingle();
            Container.BindInterfacesAndSelfTo<OhLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<OhController>().AsSingle();

        }
    }
}

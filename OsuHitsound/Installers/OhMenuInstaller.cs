using OsuHitsound.Objects;
using OsuHitsound.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace OsuHitsound.Installers
{
    class OhMenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<OhMenuButton>().AsSingle();
            Container.Bind<OhFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<OhViewController>().FromNewComponentAsViewController().AsSingle();
        }
    }
}

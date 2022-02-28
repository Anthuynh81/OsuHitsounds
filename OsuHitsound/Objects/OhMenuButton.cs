using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using OsuHitsound.UI;
using System;
using Zenject;

namespace OsuHitsound.Objects
{
    class OhMenuButton : IInitializable, IDisposable
    {
        private readonly MenuButton _menuButton;
        private readonly OhFlowCoordinator _ohFlowCoordinator;
        private readonly MainFlowCoordinator _mainFlowCoordinator;

        public OhMenuButton(
            OhFlowCoordinator ohFlowCoordinator, 
            MainFlowCoordinator mainFlowCoordinator)
        {
            _ohFlowCoordinator = ohFlowCoordinator;
            _mainFlowCoordinator = mainFlowCoordinator;
            _menuButton = new MenuButton("Osu!Hitsounds", ShowFlow);
        }

        public void Initialize()
            => MenuButtons.instance.RegisterButton(_menuButton);

        public void Dispose()
        {
            if (MenuButtons.IsSingletonAvailable && BSMLParser.IsSingletonAvailable)
                MenuButtons.instance.UnregisterButton(_menuButton);
        }

        private void ShowFlow()
        {
            _mainFlowCoordinator.PresentFlowCoordinator(_ohFlowCoordinator);
        }
    }
}

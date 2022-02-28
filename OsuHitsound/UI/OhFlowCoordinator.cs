using HMUI;
using Zenject;
using BeatSaberMarkupLanguage;

namespace OsuHitsound.UI
{
    class OhFlowCoordinator : FlowCoordinator
    {
        protected OhViewController _ohView = null!;
        protected MainFlowCoordinator _mainFlow = null!;

        [Inject]
        protected void Construct(OhViewController ohView, MainFlowCoordinator mainFlow)
        {
            _ohView = ohView;
            _mainFlow = mainFlow;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Osu!HitSounds");
                showBackButton = true;
                ProvideInitialViewControllers(_ohView);
            }

        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            _mainFlow.DismissFlowCoordinator(this);
        }
    }
}

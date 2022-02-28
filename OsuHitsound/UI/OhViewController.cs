using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using OsuHitsound.Models;
using OsuHitsound.Objects;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace OsuHitsound.UI
{
    [ViewDefinition("OsuHitsound.UI.OhViewController.bsml")]
    class OhViewController : BSMLAutomaticViewController
    {
        private OhLoader _loader = null!;
        private Config _config = null!;
        [Inject]
        protected void Construct(OhLoader loader, Config config)
        {
            _config = config;
            _loader = loader;
            hitsounds = new(loader.HitSounds);
        }
          
        [UIValue("hitsound-options")]
        private List<object> hitsounds = null!;

        [UIValue("selected-hitsound")]
        private HitsoundInfo hitsound { get=>_loader.GetHitsound(_config.SelectedHitsound); 
            set=>_config.SelectedHitsound = value.Name; }
    }
}

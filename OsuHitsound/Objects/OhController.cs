using HarmonyLib;
using SiraUtil.Affinity;
using SiraUtil.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace OsuHitsound.Objects
{
    class OhController : IAffinity
    {
        private readonly OhLoader _loader;
        private readonly Config _config;
        private SiraLog _logger;

        public OhController(
            OhLoader loader,
            Config config, SiraLog logger)
        {
            _loader = loader;
            _config = config;
            _logger = logger;
        }

        [AffinityTranspiler]
        [AffinityPatch(typeof(NoteCutSoundEffect), nameof(NoteCutSoundEffect.Init))]
        private IEnumerable<CodeInstruction> YEETHitSounds(IEnumerable<CodeInstruction> instructions) =>
            new CodeMatcher(instructions)
                .MatchForward(false, new CodeMatch(OpCodes.Ret, null))
                .Advance(-5)
                .RemoveInstructions(5)
                .InstructionEnumeration()
                .ToList();

        [AffinityPrefix]
        [AffinityPatch(typeof(NoteCutSoundEffect), nameof(NoteCutSoundEffect.NoteWasCut))]
        private void POGGERSHitSounds(AudioSource ____audioSource, bool ____noteWasCut, NoteController ____noteController, NoteController noteController)
        {
            if (____noteController != noteController || ____noteWasCut) return;

            _logger.Info(_config.SelectedHitsound);
            //_logger.Info(_loader.GetHitsound(_config.SelectedHitsound).Name);
            ____audioSource.clip = _loader.GetHitsound(_config.SelectedHitsound).Audio;
            ____audioSource.priority = 255;
            ____audioSource.volume = 1f;
            ____audioSource.Play(0);
            
            
        }
    }
}

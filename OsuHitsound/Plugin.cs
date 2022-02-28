using HarmonyLib;
using IPA;
using IPA.Loader;
using OsuHitsound.Installers;
using SiraUtil.Zenject;
using IPALogger = IPA.Logging.Logger;
using Conf = IPA.Config.Config;
using IPA.Config.Stores;

namespace OsuHitsound
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        public const string ID = "cyberfang123.osuhitsound";
        public const string CustomHitsoundsPath = "UserData/CustomHitsound";

        private readonly Harmony _harmony;
        private readonly PluginMetadata _metadata;

        [Init]
        public Plugin(IPALogger logger, Conf conf, PluginMetadata meta, Zenjector zen)
        {
            Config config = conf.Generated<Config>();
            _harmony = new Harmony(ID);
            _metadata = meta;

            zen.UseLogger(logger);
            zen.Install<OhAppInstaller>(Location.App, config);
            zen.Install<OhMenuInstaller>(Location.Menu);


            
        }

        [OnEnable]
        public void OnEnable()
        {
            _harmony.PatchAll(_metadata.Assembly);
        }

        [OnDisable]
        public void OnDisable()
        {
            _harmony.UnpatchSelf();
        }
    }
}

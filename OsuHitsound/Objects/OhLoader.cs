using OsuHitsound.Models;
using SiraUtil.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;
using System.Linq;

namespace OsuHitsound.Objects
{
    class OhLoader : IInitializable
    {
        public readonly string CustomHitsoundsFolder = Path.Combine(Environment.CurrentDirectory, Plugin.CustomHitsoundsPath);

        public List<HitsoundInfo> HitSounds { get; private set; } = new();

        private readonly AudioClipAsyncLoader _asyncLoader;

        private readonly SiraLog _logger;

        public OhLoader(
            AudioClipAsyncLoader audioClipAsyncLoader, SiraLog logger)
        {
            _asyncLoader = audioClipAsyncLoader;
            _logger = logger;
        }

        public async void Initialize()
        {
            DirectoryInfo di = new DirectoryInfo(CustomHitsoundsFolder);
            FileInfo[] files = di.GetFiles();
            foreach(FileInfo file in files)
            {
                HitsoundInfo hitsound = new HitsoundInfo {
                    Audio = await _asyncLoader.Load(Path.Combine(CustomHitsoundsFolder, file.Name)),
                    Name = file.Name
                };
                HitSounds.Add(hitsound);
            }
            
        }

        public HitsoundInfo GetHitsound(string Hitsound)
        {
            return HitSounds.FirstOrDefault(x=>x.Name==Hitsound);
        }
    }
}

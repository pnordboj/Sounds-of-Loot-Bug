using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;
using HoardingSpeaks.Patches;


namespace HoardingSpeaks
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "nordbo.HoardingSpeaks";
        private const string modName = "Loot Bug Voice Lines";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        internal ManualLogSource mls;

        public static Plugin Instance;

        internal static AudioClip[] voiceLines;
        private void Awake()
        {
            // Plugin startup logic
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo($"Plugin {modGUID} is loaded!");
            
            LoadVoiceLines();

            harmony.PatchAll(typeof(Plugin));
            harmony.PatchAll(typeof(HoarderBugPatch));

        }
        
        private void LoadVoiceLines()
        {
            voiceLines = new AudioClip[4];

            for (int i = 0; i < voiceLines.Length; i++)
            {
                voiceLines[i] = LoadAudioClip($"Assets/voice{i}.mp3");
            }
        }

        private AudioClip LoadAudioClip(string path)
        {
            return Resources.Load<AudioClip>(path);
        }
    }
    
}
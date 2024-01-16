using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace HoardingSpeaks.Patches
{
    [HarmonyPatch(typeof(HoarderBugAI))]
    internal class HoarderBugPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void HoarderBugAudioPatch(ref AudioClip[] ___chitterSFX)
        {
            ___chitterSFX = Plugin.voiceLines;
        }
    }
}

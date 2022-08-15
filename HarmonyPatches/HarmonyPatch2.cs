using AntiPause.Configuration;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// See https://github.com/pardeike/Harmony/wiki for a full reference on Harmony.
/// </summary>
namespace AntiPause.HarmonyPatches
{
    [HarmonyPatch(typeof(PauseMenuManager), nameof(PauseMenuManager.ShowMenu))]
    internal class PatchPauseMenuUI
    {
        public static bool Prefix()
        {
            if (PluginConfig.Instance.enabled)
            {
                return false;
            }
            return true;
        }
    }
}
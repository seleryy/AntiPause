using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using System.Collections.Generic;
using AntiPause.Configuration;

namespace AntiPause
{

    internal class MenuViewController : NotifiableSingleton<MenuViewController>
    {
        [UIValue("enabled")]
        private bool enabled_
        {
            get
            {
                return PluginConfig.Instance.enabled;
            }
            set
            {
                PluginConfig.Instance.enabled = value;
            }
        }
    }
}

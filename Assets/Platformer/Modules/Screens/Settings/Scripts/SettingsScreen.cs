using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Platformer.Managers;

namespace Platformer.Screens.Settings
{
    public class SettingsScreen : BaseTemplateScreen
    {
        public const string Exit_Back = "Exit_Back";
       
        public void OnBackPressed()
        {
            Exit(Exit_Back);
        }

        public void OnMusicToggleChanged(bool state)
        {
            AudioManager.I.OnToggleMenuMusic(state);
        }

        public void OnMenuSoundsToggleChanged(bool state)
        {
            AudioManager.I.OnToggleMenuSounds(state);
        }
        
    }
}

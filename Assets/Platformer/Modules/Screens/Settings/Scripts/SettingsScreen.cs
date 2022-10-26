using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Template.Managers;

namespace Template.Screens.Settings
{
    public class SettingsScreen : BaseTemplateScreen
    {
        public const string Exit_Back = "Exit_Back";
        private AudioMixer audioMixer;
        private void OnEnable()
        {
            base.OnEnable();

            audioMixer = FindObjectOfType<AudioManager>().GetAudioMixer;
        }
        public void OnBackPressed()
        {
            Exit(Exit_Back);
        }

        public void ChangeMainMenuMusicState(bool state)
        {
            if (state)
            {
                audioMixer.SetFloat(AudioManager.MainMenuMusic, 0f);
            }
            else
            {
                audioMixer.SetFloat(AudioManager.MainMenuMusic, -80f);
            }
        }

        public void ChangeMenuSounds(bool state)
        {
            if (state)
            {
                audioMixer.SetFloat(AudioManager.MenuSounds, 0f);
            }
            else
            {
                audioMixer.SetFloat(AudioManager.MenuSounds, -80f);
            }
        }
    }
}

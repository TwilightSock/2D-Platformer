using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuiceKit;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Template.Managers
{
    public class AudioManager : BaseManager<AudioManager>
    {
        [SerializeField]
        private AudioMixer audioMixer;

        private const string MainMenuMusic = "MainMenuMusic";
        private const string MenuSounds = "MenuSounds";

       
        public void ChangeMainMenuMusicState(bool state) 
        {
            if (state)
            {
                audioMixer.SetFloat(MainMenuMusic, 0f);
            }
            else 
            {
                audioMixer.SetFloat(MainMenuMusic, -80f);
            }
        }

        public void ChangeMenuSounds(bool state) 
        {
            if (state)
            {
                audioMixer.SetFloat(MenuSounds, 0f);
            }
            else
            {
                audioMixer.SetFloat(MenuSounds, -80f);
            }
        }
    }
}

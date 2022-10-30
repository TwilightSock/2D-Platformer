using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuiceKit;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Platformer.Managers
{
    public class AudioManager : BaseManager<AudioManager>
    {
        static readonly string MenuMusic = "MenuMusic";
        static readonly string MenuSounds = "MenuSounds";
        static readonly string GameMenuSounds = "GameMenuSounds";
        static readonly string GameSounds = "GameSounds";
        
        [SerializeField]
         AudioMixer audioMixer;

        public void OnToggleMenuMusic(bool _state) 
        {
            SetVolume(_state, MenuMusic);
        }

        public void OnToggleMenuSounds(bool _state) 
        {
            SetVolume(_state, MenuSounds);
        }

        public void OnToggleGameMenuSounds(bool _state) 
        {
            SetVolume(_state, GameMenuSounds);
        }

        public void OnToggleGameSounds(bool _state)
        {
            SetVolume(_state, GameSounds);
        }
        void SetVolume(bool _state,string _groupName)
        {
            if (_state)
            {
                audioMixer.SetFloat(_groupName, 0f);
            }
            else
            {
                audioMixer.SetFloat(_groupName, -80f);
            }
        }
    }
}

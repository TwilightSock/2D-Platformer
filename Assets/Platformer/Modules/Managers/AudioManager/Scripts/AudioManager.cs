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

        public static readonly string MainMenuMusic = "MainMenuMusic";
        public static readonly string MenuSounds = "MenuSounds";
        public static readonly string GameMenuSounds = "GameMenuSounds";
        public static readonly string GameSounds = "GameSounds";

        public AudioMixer GetAudioMixer 
        {
            get { return audioMixer; }
        }
        
    }
}

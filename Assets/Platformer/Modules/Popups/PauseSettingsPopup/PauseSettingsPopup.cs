using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuiceKit;
using Platformer.Managers;

namespace Platformer.Popups
{
    public class PauseSettingsPopup : BasePopup
    {
        public void OnBackPressed() 
        {
            gameObject.SetActive(false);
        }
        public void OnToggleSoundsSwitch(bool _state)
        {
            AudioManager.I.OnToggleGameSounds(_state);
        }
    }
}

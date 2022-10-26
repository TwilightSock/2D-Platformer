using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuiceKit;
using System;

namespace Template.Popups
{
    public class PauseMenuPopup : BasePopup
    {
        private Action onPopupActive;
        private GameObject popup;
        public void OnSwitchPopupPressed()
        {
            onPopupActive();
            popup.SetActive(!popup.activeSelf);
        }

        public void PausePopupOnActive(Action action) 
        { 
            onPopupActive = action;
        }
    }
}

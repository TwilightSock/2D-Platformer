using System.Collections;
using System.Collections.Generic;
using Template.UIElements;
using UnityEditor;
using UnityEngine;

namespace Template.Screens.Level1
{
    public class Level1Screen : BaseTemplateScreen
    {
        public const string Exit_Quit = "Exit_Quit";
        public const string Exit_Restart = "Exit_Restart";
        [SerializeField]
        private PopupUIE popupUIE;
        public void OnQuitPressed()
        {
            Exit(Exit_Quit);
        }

        public void OnRestartPressed()
        {
            Exit(Exit_Restart);
        }

        public void OnSettingsPressed() 
        {
            
        }

        public void OnSwitchPopupPressed() 
        {
            popupUIE.gameObject.SetActive(!popupUIE.gameObject.activeSelf);
        }
    }
}

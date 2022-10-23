using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.Screens.Menu
{
    public class MenuScreen : BaseTemplateScreen
    {
        public const string Exit_Play = "Exit_Play";
        public const string Exit_Settings = "Exit_Settings";
        public const string Exit_Quit = "Exit_Quit";

        public void OnPlayPressed()
        {
            Exit(Exit_Play);
        }

        public void OnSettingsPressed()
        {
            Exit(Exit_Settings);
        }

        public void OnQuitPressed()
        {
            Exit(Exit_Quit);
        }
    }
}

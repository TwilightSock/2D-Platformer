using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.Screens.Settings
{
    public class SettingsScreen : BaseTemplateScreen
    {
        public const string Exit_Back = "Exit_Back";

        public void OnBackPressed()
        {
            Exit(Exit_Back);
        }
    }
}

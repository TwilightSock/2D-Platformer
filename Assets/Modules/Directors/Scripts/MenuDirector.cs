using JuiceKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Template.Screens.Menu;
using Template.Screens.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Directors
{
    public class MenuDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            AddExitAction<MenuScreen>(OnMenuScreenExit);
            AddExitAction<SettingsScreen>(OnSettingsScreenExit);

            SetCurrentScreen<MenuScreen>().Show();
        }

        void OnMenuScreenExit(string _exitCode)
        {
            if (_exitCode == MenuScreen.Exit_Play)
            {
                SceneManager.LoadScene(ScenesIds.Game);
            }
            else if (_exitCode == MenuScreen.Exit_Settings)
            {
                ToScreen<SettingsScreen>();
            }
            else if (_exitCode == MenuScreen.Exit_Develop)
            {
                LoadScene(ScenesIds.Develop);
            }
        }

        void OnSettingsScreenExit(string _exitCode)
        {
            if (_exitCode == SettingsScreen.Exit_Back)
            {
                ToBackScreen();
            }
        }
    }
}

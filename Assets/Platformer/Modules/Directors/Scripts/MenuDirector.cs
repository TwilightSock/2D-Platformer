using JuiceKit;
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
                SceneManager.LoadScene(ScenesIds.Level1);
            }
            else if (_exitCode == MenuScreen.Exit_Settings)
            {
                //ToScreen<SettingsScreen>();
            }
            else if (_exitCode == MenuScreen.Exit_Quit)
            {
                Application.Quit(); 
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

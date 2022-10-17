using JuiceKit;
using System;
using System.Collections;
using System.Collections.Generic;
using Template.Screens.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Template.Directors
{
    public class GameDirector : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            AddExitAction<GameScreen>(OnGameScreenExit);

            SetCurrentScreen<GameScreen>().Show();
        }

        void OnGameScreenExit(string _exitCode)
        {
            if (_exitCode == GameScreen.Exit_Finish)
            {
                SceneManager.LoadScene(ScenesIds.Menu);
            }
        }
    }
}

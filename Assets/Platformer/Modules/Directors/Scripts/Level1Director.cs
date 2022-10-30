using JuiceKit;
using Platformer.Screens.Game;
using UnityEngine.SceneManagement;

namespace Platformer.Directors
{
    public class Level1Director : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            AddExitAction<GameScreen>(OnGameScreenExit);

            SetCurrentScreen<GameScreen>().Show();
        }

        void OnGameScreenExit(string _exitCode)
        {
            if (_exitCode == GameScreen.Exit_Quit)
            {
                SceneManager.LoadScene(ScenesIds.Menu);
            }
            else if (_exitCode == GameScreen.Exit_Restart) 
            {
                SceneManager.LoadScene(ScenesIds.Level1);
            }
        }
    }
}

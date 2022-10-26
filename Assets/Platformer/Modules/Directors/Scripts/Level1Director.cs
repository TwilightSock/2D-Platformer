using JuiceKit;
using Template.Screens.Level1;
using UnityEngine.SceneManagement;

namespace Template.Directors
{
    public class Level1Director : SceneDirector
    {
        protected override void Start()
        {
            base.Start();

            AddExitAction<Level1Screen>(OnGameScreenExit);

            SetCurrentScreen<Level1Screen>().Show();
        }

        void OnGameScreenExit(string _exitCode)
        {
            if (_exitCode == Level1Screen.Exit_Quit)
            {
                SceneManager.LoadScene(ScenesIds.Menu);
            }
            else if (_exitCode == Level1Screen.Exit_Restart) 
            {
                SceneManager.LoadScene(ScenesIds.Level1);
            }
        }
    }
}

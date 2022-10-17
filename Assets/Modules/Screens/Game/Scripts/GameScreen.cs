using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Template.Screens.Game
{
    public class GameScreen : BaseTemplateScreen
    {
        public const string Exit_Finish = "Exit_Finish";

        public void OnFinishPressed()
        {
            Exit(Exit_Finish);
        }
    }
}

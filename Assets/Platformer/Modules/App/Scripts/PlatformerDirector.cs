using JuiceKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Platformer.App
{
    public class PlatformerDirector : AppDirector
    {
        protected override void Start()
        {
            base.Start();

            SceneManager.LoadScene(ScenesIds.Menu);
        }

        protected override void OnAppDeactivate()
        {
            //Save app data here
            //Set notifications
        }

        protected override void OnAppResume()
        {
            //Reset notifications here
        }
    }
}

using JuiceKit.Components;
using Platformer.Controllers;
using Platformer.Elements;
using Platformer.Popups;
using TMPro;
using UnityEngine;

namespace Platformer.Screens.Game
{
    public class GameScreen : BaseTemplateScreen
    {
        public const string Exit_Quit = "Exit_Quit";
        public const string Exit_Restart = "Exit_Restart";
        [SerializeField]
        GameObject pauseMenuPopup;
        [SerializeField]
        GameObject pauseSettingsPopup;

        [SerializeField] double timeToLose;
        [SerializeField] Controllers.CharacterController character;      
        [SerializeField] EndLevelElement endLevel;
        [SerializeField] ResultPopup resultPopup;
        [SerializeField] TMP_Text coinText;
        [SerializeField] Timer timer;
        [SerializeField] TMP_Text timerText;
        

        [SerializeField] private AdMobController advert;

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
            pauseSettingsPopup.SetActive(true);
        }

        public void OnSwitchPopupPressed()
        {           
            pauseMenuPopup.SetActive(!pauseMenuPopup.activeSelf);
        }

        void Start() 
        {
            
            IsGamePaused = true;
            PauseGameState();
            //Time.timeScale = 1;
            
            timer.IsUnscaledTime = false;
            timer.StartTimer(timeToLose, () => GameEnd(GameEndStates.Defeat));
        }

        protected override void Update()
        {
            base.Update();
            Timer();
            PauseGameState();
            OutputCoins();
            
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            character.CharacterOnDeathAction(() => GameEnd(GameEndStates.Defeat));
            endLevel.onLevelComplete = () => GameEnd(GameEndStates.Victory);
        }
        protected override void OnUserBackPressed()
        {
            base.OnUserBackPressed();
            OnSwitchPopupPressed();
        }

        void OutputCoins()
        {
            coinText.SetText(character.CharacterCoinsCollected.ToString());
        }

        void Timer()
        {
            if (pauseMenuPopup.activeSelf | resultPopup.gameObject.activeSelf)
            {
                timer.PauseTimer();
            }
            else
            {
                if (timer.IsPaused)
                {
                    timer.ResumeTimer();
                }

                timerText.SetText(timer.RemainingTime.ToString("0.0"));
            }

        }

        void GameEnd(string _state)
        {
            resultPopup.Show(_state, ShowAdvert);

        }

        void PauseGameState()
        {
            if (pauseMenuPopup.activeSelf || resultPopup.gameObject.activeSelf)
            {
                Time.timeScale = 0;
                IsGamePaused = true;
            }
            else 
            {
                if (IsGamePaused) 
                {
                    Time.timeScale = 1;
                    IsGamePaused = false;
                }
            }
            
        }
        void ShowAdvert()
        {
            if (advert.interstitialAd.IsLoaded())
            {
                advert.interstitialAd.Show();
            }
        }

        public bool IsGamePaused { get; private set; } 
    }
}

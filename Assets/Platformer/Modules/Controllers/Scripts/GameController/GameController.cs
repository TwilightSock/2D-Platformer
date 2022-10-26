using JuiceKit;
using JuiceKit.Components;
using System.Collections;
using System.Collections.Generic;
using Template.Elements;

using Template.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Template.Controllers
{
    public class GameController : Controller
    {
        public double timeToLose;
        [SerializeField]
        private CharacterController character;

        [SerializeField] private EndLevelElement endLevel;
        [SerializeField] private ResultPopupUIE resultPopup;
        [SerializeField] private TMP_Text coinText;
        [SerializeField] private Timer timer;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private GameObject popup;

        [SerializeField] private AdMobController advert;

        private void Start()
        {
            timer.StartTimer(timeToLose, () => GameEnd(GameEndStates.Defeat));
        }
        private void Update()
        {
            /*if (!character.isDead & !popup.activeSelf)
            {
                character.JumpPlayer(Input.GetButtonDown("Jump"));
            }

            character.DiePlayer();*/
            OutputCoins();
            Timer();

        }

       /* private void FixedUpdate()
        {
            if (!character.isDead & !popup.activeSelf)
            {
                character.MovePlayer(Input.GetAxis("Horizontal"));
            }
        }*/

        private void OnEnable()
        { 
            resultPopup.GetComponent<ResultPopupUIE>().onPopupClose = SceneRestart;
            //popup.GetComponent<PauseMenuPopup>().PausePopupOnActive(character.CharacterFreezeMove);
            character.CharacterOnDeathAction(() => GameEnd(GameEndStates.Defeat));
            endLevel.onLevelComplete = () => GameEnd(GameEndStates.Victory);
        }

        private void SceneRestart(int BuildIndex)
        {
            SceneManager.LoadScene(BuildIndex);
        }

        private void OutputCoins()
        {
            coinText.SetText(character.CharacterCoinsCollected.ToString());
        }

        private void Timer()
        {
            if (popup.activeSelf | resultPopup.gameObject.activeSelf)
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

        private void GameEnd(string state)
        {
            character.CharacterFreezeMove();
            resultPopup.Show(state, ShowAdvert);

        }

        private void ShowAdvert()
        {
            if (advert.interstitialAd.IsLoaded())
            {
                advert.interstitialAd.Show();
            }
        }
    }
}

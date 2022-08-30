using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Character character;

    [SerializeField] private EndLevelController endLevel;
    [SerializeField] private ResultPopup resultPopup;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Timer timer;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject popup;
    private void Update()
    {
        if (!character.isDead & !popup.activeSelf)
        {
            character.JumpPlayer(Input.GetButtonDown("Jump"));
        }

        character.DiePlayer();
        OutputCoins();
        Timer();
       
    }

    private void FixedUpdate()
    {
        if (!character.isDead & !popup.activeSelf)
        {
            character.MovePlayer(Input.GetAxis("Horizontal"));
        }
    }

    private void OnEnable()
    {
        /*character.animatorListener.onAnimationEnd += SceneRestart;*/
        popup.GetComponent<ResultPopup>().onPopupClose += SceneRestart;
        timer.onTimerEnd += GameEnd;
        character.onCharacterDeath += GameEnd;
        endLevel.onLevelComplete += GameEnd;
    }

    private void SceneRestart(int BuildIndex)
    {
        SceneManager.LoadScene(BuildIndex);
    }

    private void OutputCoins()
    {
        text.SetText(character.coinsCollected.ToString());
    }

    private void Timer()
    {
        if (popup.activeSelf | resultPopup.gameObject.activeSelf )
        {
            timer.timerOn = false;
        }
        else 
        {
            timer.timerOn = true;
            timerText.SetText(timer.GetTime());
        }
        
    }

    private void GameEnd(ResultPopup.State state) 
    {
        character.FreezePlayer();        
        resultPopup.Show(state, SceneRestart);
        
    }

}

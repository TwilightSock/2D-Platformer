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
    [SerializeField] private Result result;
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
        if (!popup.activeSelf)
        {
            Timer();
        }
        
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
        timer.onTimerEnd += GameEnd;
        character.onCharacterDeath += GameEnd;
        endLevel.onLevelComplete += GameEnd;
    }

    /*private void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    private void OutputCoins()
    {
        text.SetText(character.coinsCollected.ToString());
    }

    private void Timer()
    {
        timerText.SetText(timer.GetTime());
    }

    private void GameEnd(Result.State state) 
    {
        result.SetState(state);
        if (popup.activeSelf)
        {
            character.FreezePlayer();
        }
    }

}

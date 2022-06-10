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
    [SerializeField]
    private Timer timer;

    [SerializeField] private TMP_Text timerText;
    private void Update()
    {
        if (!character.isDead)
        {
            character.JumpPlayer(Input.GetButtonDown("Jump"));
        }

        character.DiePlayer();
        OutputCoins();
        Timer();
        GameStatus();
    }

    private void FixedUpdate()
    {
        if (!character.isDead)
        {
            character.MovePlayer(Input.GetAxis("Horizontal"));
        }
    }
    private void OnEnable()
    {
        character.animatorListener.onAnimationEnd += SceneRestart;
    }

    private void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OutputCoins()
    {
        text.SetText(character.coinsCollected.ToString());
    }

    private void Timer()
    {
        timerText.SetText(timer.GetTime());
    }

    private void GameStatus()
    {
        if (endLevel.levelCompleted)
        {
            result.SetVictory();
        }

        if (character.isDead || !timer.timerOn)
        {
            result.SetDefeat();
        }

    }
}

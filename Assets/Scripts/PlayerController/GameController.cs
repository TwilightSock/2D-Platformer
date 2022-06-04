using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Character character;
    private void Update()
    {
        if (!character.isDead)
        {
            character.JumpPlayer(Input.GetButtonDown("Jump"));
        }

        character.DiePlayer();
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
}

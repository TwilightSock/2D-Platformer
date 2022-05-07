using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Character character;

    private void OnEnable()
    {
        character.animatorListener.onActionRestart += SceneRestart;
    }

    private void SceneRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

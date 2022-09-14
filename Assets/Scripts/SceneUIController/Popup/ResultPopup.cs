using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPopup : MonoBehaviour
{
    public Action<int> onPopupClose;
    [SerializeField]
    private TMP_Text resultText;
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private GameObject menu;
    public enum State
    {
        Victory,
        Defeat
    }

    public void OnSwitch()
    {
        clickSound.Play();
        menu.SetActive(!menu.activeSelf);
    }

    public void OnQuit()
    {
        clickSound.Play();
        onPopupClose(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnSettings()
    {
        clickSound.Play();
    }

    public void OnRestart()
    {
        clickSound.Play();
        onPopupClose(SceneManager.GetActiveScene().buildIndex);
    }


    public void Show(State state,Action onPopupClose)
    {
        gameObject.SetActive(true);
       // this.onPopupClose += onPopupClose;
        resultText.SetText(state.ToString());

        if (state.Equals(State.Victory))
        {
            resultText.color = Color.green;
        }

        if (state.Equals(State.Defeat))
        {
            resultText.color = Color.red;
        }
        onPopupClose();
    }
}

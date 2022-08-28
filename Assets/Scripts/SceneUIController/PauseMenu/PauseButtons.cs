using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private GameObject menu;

    public void OnClose()
    {
        clickSound.Play();
        menu.SetActive(false);
    }

    public void OnQuit()
    {
        clickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public void OnSettings()
    {
        clickSound.Play();
    }

    public void OnRestart()
    {
        clickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

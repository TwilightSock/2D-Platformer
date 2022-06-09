using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private GameObject pauseMenu;

    public void OnClose()
    {
        AudioSource.PlayClipAtPoint(clickSound.clip,transform.position);
        pauseMenu.SetActive(false);
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

}

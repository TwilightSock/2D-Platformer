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
        AudioSource.PlayClipAtPoint(clickSound.clip,transform.position);
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

}

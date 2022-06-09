using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField]
    private AudioSource clickSound;

    public void OnPlay()
    {
        clickSound.Play();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnSettings()
    {
        clickSound.Play();
    }

    public void OnShop()
    {
        clickSound.Play();
    }

    public void OnQuit()
    {
        clickSound.Play();
        Application.Quit();
    }
}

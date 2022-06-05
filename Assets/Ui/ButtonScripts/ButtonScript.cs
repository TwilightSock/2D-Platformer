using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnSettings()
    {
    }

    public void OnShop()
    {
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}

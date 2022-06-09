using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonOpen : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField]
    private GameObject pauseMenu;
    public void OnOpen()
    {
        clickSound.Play();
        pauseMenu.SetActive(true);
    }
}

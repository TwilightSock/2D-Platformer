using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonOpen : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    [SerializeField]
    private GameObject menu;
    public void OnOpen()
    {
        clickSound.Play();
        menu.SetActive(true);
    }
}

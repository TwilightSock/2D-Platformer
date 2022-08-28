using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOnChoose : MonoBehaviour
{
    [SerializeField] private AudioSource chooseSound;
    public void OnMouseEnter()
    {
        chooseSound.Play();
    }
}

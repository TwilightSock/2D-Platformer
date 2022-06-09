using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelController : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;
    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            OnLevelComplete();

        }
    }

    private void OnLevelComplete()
    {

    }
}

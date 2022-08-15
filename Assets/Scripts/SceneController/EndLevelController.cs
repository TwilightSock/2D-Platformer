using System;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelController : MonoBehaviour
{
    public Action<Result.State> onLevelComplete;
    [SerializeField] private AudioSource finishSound;
    public bool levelCompleted { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            onLevelComplete(Result.State.Victory);
        }
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;
using Template.UIElements;
public class EndLevelController : MonoBehaviour
{
    public Action<ResultPopupUIE.State> onLevelComplete;
    [SerializeField] private AudioSource finishSound;
    public bool levelCompleted { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player") && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            onLevelComplete(ResultPopupUIE.State.Victory);
        }
    }

}

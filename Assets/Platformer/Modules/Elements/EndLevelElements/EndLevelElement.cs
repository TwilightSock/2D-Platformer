using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuiceKit;

namespace Template.Elements
{
    public class EndLevelElement : Element
    {
        public Action onLevelComplete;
        [SerializeField] private AudioSource finishSound;
        public bool levelCompleted { get; private set; } = false;

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player") && !levelCompleted)
            {
                finishSound.Play();
                levelCompleted = true;
                onLevelComplete();
            }
        }
    }
}

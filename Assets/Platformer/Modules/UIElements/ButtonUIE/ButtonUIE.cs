using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JuiceKit;

namespace Template.UIElements
{
    public class ButtonUIE : UIElement
    {
        [SerializeField]
        private AudioSource chooseSound;
        [SerializeField]
        private AudioSource clickSound;

        public void OnMouseDown()
        {
            clickSound.Play();
        }

        public void OnMouseEnter()
        {
            chooseSound.Play();
        }
    }
}

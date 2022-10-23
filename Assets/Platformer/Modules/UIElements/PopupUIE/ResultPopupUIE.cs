using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Template.UIElements
{
    public class ResultPopupUIE : MonoBehaviour
    {
        public Action<int> onPopupClose;
        [SerializeField]
        private TMP_Text resultText;
        public enum State
        {
            Victory,
            Defeat
        }
        public void Show(State state, Action onPopupClose)
        {
            gameObject.SetActive(true);
            // this.onPopupClose += onPopupClose;
            resultText.SetText(state.ToString());

            if (state.Equals(State.Victory))
            {
                resultText.color = Color.green;
            }

            if (state.Equals(State.Defeat))
            {
                resultText.color = Color.red;
            }
            onPopupClose();
        }
    }
}

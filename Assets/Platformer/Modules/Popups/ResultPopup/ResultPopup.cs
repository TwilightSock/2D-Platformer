using JuiceKit;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Template.Popups
{
    public class ResultPopup : BasePopup
    {
        public Action<int> onPopupClose;
        [SerializeField]
        private TMP_Text resultText;
        
        public void Show(string state, Action onPopupClose)
        {
            gameObject.SetActive(true);
  
            resultText.SetText(state.ToString());

            if (state == GameEndStates.Victory)
            {
                resultText.color = Color.green;
            }

            if (state == GameEndStates.Defeat)
            {
                resultText.color = Color.red;
            }
            onPopupClose();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resultText;
    public enum State 
    {
        Victory,
        Defeat
    }
    public void SetState(State state)
    {
        gameObject.SetActive(true);
        if (resultText.text == string.Empty) 
        {
            resultText.SetText(state.ToString());

            if (state.Equals(State.Victory))
            {
                resultText.color = Color.green;
            }

            if (state.Equals(State.Defeat))
            {
                resultText.color = Color.red;
            }

        }
        
    }
}

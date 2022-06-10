using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Result : MonoBehaviour
{
    [SerializeField]
    private TMP_Text resultText;
    
    public void SetVictory()
    {   
        gameObject.SetActive(true);
        resultText.SetText("Victory");
        resultText.color = Color.green;
    }

    public void SetDefeat()
    {
        gameObject.SetActive(true);
        resultText.SetText("Defeat");
        resultText.color = Color.red;
    }
}

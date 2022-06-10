using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn { get; private set; } = false;

    private void Start()
    {
        timerOn = true;
    }

    private void Update()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
            }
            else
            {
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

    public string GetTime()
    {
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        float minutes = Mathf.FloorToInt(timeLeft / 60);

        return minutes.ToString()+" : " + seconds.ToString() ;
    }
}

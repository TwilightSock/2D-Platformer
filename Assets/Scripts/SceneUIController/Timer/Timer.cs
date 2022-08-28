using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Action<Result.State> onTimerEnd;
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
                onTimerEnd(Result.State.Defeat);
                              
            }
        }
    }

    public string GetTime()
    {
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        if (seconds < 0 | minutes < 0) 
        {
            seconds = 0;   
            minutes = 0;
        }
        return minutes.ToString()+" : " + seconds.ToString() ;
    }
}

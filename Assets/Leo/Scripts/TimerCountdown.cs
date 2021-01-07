using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public Slider timeToAnswer;
    public GameObject 

    //Collegamento all'evento;
    private void OnEnable()
    {
        LevelManager.onStartClick += Update;
    }

    private void OnDisable()
    {
        LevelManager.onStartClick -= Update;
    }
    private void Update()
    {
        timeToAnswer.value -= Time.deltaTime;
        if (timeToAnswer.value < 5)
        {
            timeToAnswer. = Mathf.Lerp(87, 45, Time.deltaTime);
        }
        if (timeToAnswer.value < Mathf.Epsilon)
        {
            Debug.Log("Timer finito hai perso");
        }
    }
}

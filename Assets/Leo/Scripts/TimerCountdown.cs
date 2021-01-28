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
    public GameObject timeRemaining;

    private int sliderToBecomeYellow = 6;
    private int sliderToBecomeRed = 3;

    private void Update()
    {
        timeToAnswer.value -= Time.deltaTime;
        
        //Impostazione del colore del tempo in base al tempo mancante
        if (timeToAnswer.value > sliderToBecomeRed  &&  timeToAnswer.value < sliderToBecomeYellow)
        {
            timeRemaining.GetComponent<Image>().color = Color.yellow;
        }
        else if (timeToAnswer.value < sliderToBecomeRed)
        {
            timeRemaining.GetComponent<Image>().color = Color.red;
        }
        else
        {
            timeRemaining.GetComponent<Image>().color = Color.green;
        }
        
        if (timeToAnswer.value < Mathf.Epsilon)
        {
            Debug.Log("Timer finito hai perso");
        }
    }
}

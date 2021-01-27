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

    private void Update()
    {
        timeToAnswer.value -= Time.deltaTime;
        
        //Impostazione del colore del tempo in base al tempo mancante
        if (timeToAnswer.value > 3  &&  timeToAnswer.value < 6)
        {
            timeRemaining.GetComponent<Image>().color = Color.yellow;
        }
        else if (timeToAnswer.value < 3)
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

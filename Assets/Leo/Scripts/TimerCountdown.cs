using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public Slider timeToAnswer;
    public GameObject timeRemaining;

    private int sliderToBecomeYellow = 6;
    private int sliderToBecomeRed = 3;
    
    //
    private EffectsManager _effectsManager;


    private void Start()
    {
        _effectsManager = FindObjectOfType<EffectsManager>();
    }

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
            if (!(GameManager.Instance.textPlaying))
            {
                //Gestisce il GameOver dovuto allo scadere del tempo.
            
                _effectsManager.HideBoxQuestionAndTimer();
                _effectsManager.ShowGameOverText();
                //Set del levelOrigin nel livello appena raggiunto(ritentare).
                GameManager.Instance.LevelOriginIndex = GameManager.Instance.LevelDestinationIndex;
                //Ricarica il menù di selezione del livello, dopo un certo delay.
                Invoke("LoadLevelSelectionMap",5);
            }

        }
    }
    
    public void LoadLevelSelectionMap()
    {
        SceneManager.LoadScene(0);
    }
}

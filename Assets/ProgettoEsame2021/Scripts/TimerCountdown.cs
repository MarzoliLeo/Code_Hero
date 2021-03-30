﻿using ProgettoEsame2021.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public Slider timeToAnswer;
    public GameObject timeRemaining;

    public float speedOfTime = 1f;
    
    private int sliderToBecomeYellow = 6;
    private int sliderToBecomeRed = 3;

    //
    private EffectsManager _effectsManager;
    private Image _image;
    
    //
    private bool timerScaling;

    public bool TimerScaling
    {
        get => timerScaling;
        set => timerScaling = value;
    }


    private void Start()
    {
        _effectsManager = FindObjectOfType<EffectsManager>();
        _image = timeRemaining.GetComponent<Image>();
    }

    private void Update()
    {
        
        timeToAnswer.value -= Time.deltaTime * speedOfTime;

        //Impostazione del colore del tempo in base al tempo mancante
        if (timeToAnswer.value > sliderToBecomeRed  &&  timeToAnswer.value < sliderToBecomeYellow)
        {
            _image.color = Color.yellow;
        }
        else if (timeToAnswer.value < sliderToBecomeRed)
        {
            _image.color = Color.red;
        }
        else
        {
            _image.color = Color.green;
        }
        
        if (timeToAnswer.value < Mathf.Epsilon)
        {
            if (GameManager.Instance.TextPlaying == false)
            {
                //Gestisce il GameOver dovuto allo scadere del tempo.

                _effectsManager.HideBoxQuestionAndTimer();
                _effectsManager.ShowGameOverText();
                //Set del levelOrigin nel livello appena raggiunto(ritentare).
                GameManager.Instance.LevelOriginIndex = GameManager.Instance.LevelDestinationIndex;
                //Ricarica il menù di selezione del livello, dopo un certo delay.
                Invoke("LoadMainMap", 5);
            }
        }
    }
    
    public void LoadMainMap()
    {
        SceneManager.LoadScene(0);
    }
}
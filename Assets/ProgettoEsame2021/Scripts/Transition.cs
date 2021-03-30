using System;
using System.Collections;
using System.Collections.Generic;
using ProgettoEsame2021.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private  int secondsToWait = 5;

    private void Start()
    {
        Invoke(methodName: "LoadPowerupScene", time: secondsToWait);
    }
    
    //Metodo per caricare il livello rispettivamente all'index.
    private void LoadPowerupScene()
    {
        //SceneManager.LoadScene(GameManager.Instance.DestinationWaypoint.levelIndex);
        //Todo Creare un delay per fare partire il suono
        //SoundManager.Instance.PlayFightSound();

        SceneManager.LoadScene("Powerup");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    private  int secondsToWait = 5;

    private void Start()
    {
        Invoke(methodName: "LoadIndexLevel", time: secondsToWait);
    }
    
    //Metodo per caricare il livello rispettivamente all'index.
    private void LoadIndexLevel()
    {
        SceneManager.LoadScene(GameManager.Instance.DestinationWaypoint.levelIndex);
    }
    
}

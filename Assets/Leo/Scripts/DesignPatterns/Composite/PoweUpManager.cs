using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoweUpManager : Singleton<PoweUpManager>
{
    //Creazione delle foglie
    public IComponent increaseDmg = new PowerUp("Increase Damage");
    public IComponent increaseHealth = new PowerUp("Increase Health");
    public IComponent slowTimer = new PowerUp("Slow Timer");


    //Riferimenti ad altre classi per il powerUp dei danni.
    private Player _player;

    public GameObject powerUpIncreaseDamage;
    public GameObject powerUpIncreaseHealth;
    public GameObject powerUpSlowTimer;
    
    
    //Collegamento dall'evento.
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    //Scollegamento dall'evento.
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    //Ad ogni caricamento di una nuova scena esegue questo metodo.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Mostrare a video i powerup
        if (scene.name.Equals("Powerup"))
        {
            StartCoroutine(ChangeAnimationToDespawnAndShowPowerUp());
        }
        
        if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition") || scene.name.Equals("Powerup")))
        {
            
            //Istanza dei riferimenti.
            _player = FindObjectOfType<Player>();
            
            //If per gestire il powerUp IncreaseDamage
            if (increaseDmg.Active)
            {
                if(_player != null)
                    _player.Damage = 2;
                
                increaseDmg.Active = false;
            }
            
            //If per gestire il powerUp IncreaseHealth
            if (increaseHealth.Active)
            {
                //IncreaseHealth();
            }
            
            //If per gestire il powerUp SlowTimer
            if (slowTimer.Active)
            {
                FindObjectOfType<TimerCountdown>().speedOfTime = 0.6f;
                slowTimer.Active = false;
            }
            else
            {
                FindObjectOfType<TimerCountdown>().speedOfTime = 1f;
            }
        }
    }

    //Coroutine che permette di gestire il flusso di animazioni a video del Powerup
    IEnumerator ChangeAnimationToDespawnAndShowPowerUp()
    {
        yield return new WaitForSeconds(1);
        
        GameObject.Find("CommonBox(Clone)").GetComponent<Animator>().SetBool("CloseBox",true);
        GameObject.Find("RareBox(Clone)").GetComponent<Animator>().SetBool("CloseBox",true);
        GameObject.Find("LegendaryBox(Clone)").GetComponent<Animator>().SetBool("CloseBox",true);
        
        yield return  new WaitForSeconds(1);
        
        if (increaseDmg.Active)
        {
            Instantiate(powerUpIncreaseDamage, transform.position, Quaternion.identity);
        }

        if (increaseHealth.Active)
        {
            Instantiate(powerUpIncreaseHealth, transform.position, Quaternion.identity);
        }

        if (slowTimer.Active)
        {
            Instantiate(powerUpSlowTimer, transform.position, Quaternion.identity);
        }
        
        
        
    }
    
}

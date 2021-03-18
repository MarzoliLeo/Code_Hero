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
    
    //Riferimenti ad altre classi per il powerUp della vita.
    
    //Riferimenti ad altre classi per il powerUp del tempo.
    
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
        if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition") || scene.name.Equals("Powerup")))
        {
            
            //Istanza dei riferimenti.
            _player = FindObjectOfType<Player>();

            if (increaseDmg.Active)
            {
                IncreaseDamage();
            }
            else if (increaseHealth.Active)
            {
                //Todo aumentare la health del player di 1
                IncreaseHealth();
            }
            else if (slowTimer.Active)
            {
                //Todo rallentare la velocita' del Timer.
                SlowTimer();
            }
        }
    }
    
    //Metodo per applicare il PowerUp "Increase Damage"
    private void IncreaseDamage()
    {
        if(_player != null)
            _player.Damage = 2;
    }
    
    //Metodo per applicare il PowerUp "Increase Health"
    private void IncreaseHealth()
    {
        if (_player != null)
        {
            
        }
    }
    
    //Metodo per applicare il PowerUp "Slow Timer"
    private void SlowTimer()
    {
        
    }
    
}

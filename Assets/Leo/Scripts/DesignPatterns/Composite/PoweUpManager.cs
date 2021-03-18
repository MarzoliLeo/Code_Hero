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
                if(_player != null)
                    _player.Damage = 2;
                
                increaseDmg.Active = false;
            }
            else if (increaseHealth.Active)
            {
                //Sistemare i bug relativi all'incremento di vita fatto nel  GameManager.
                //IncreaseHealth();
            }
            else if (slowTimer.Active)
            {
                FindObjectOfType<TimerCountdown>().speedOfTime = 5000f;
                slowTimer.Active = false;
            }
        }
    }
    
    
}

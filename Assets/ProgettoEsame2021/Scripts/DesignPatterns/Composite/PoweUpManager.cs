using System.Collections;
using ProgettoEsame2021.Scripts.DesignPatterns.State;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProgettoEsame2021.Scripts.DesignPatterns.Composite
{
    public class PoweUpManager : Singleton<PoweUpManager>
    {
        //Creazione delle foglie (PowerUps).
        public IComponent increaseDmg = new PowerUp("Increase Damage");
        public IComponent increaseHealth = new PowerUp("Increase Health");
        public IComponent slowTimer = new PowerUp("Slow Timer");
        
        //Riferimenti ad altre classi.
        private Player _player;

        //Oggetti di gioco per mostrare i PowerUp a video.
        public GameObject powerUpIncreaseDamage;
        public GameObject powerUpIncreaseHealth;
        public GameObject powerUpSlowTimer;
        
        //Collegamento all'evento attivato dal cambio di una scena.
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    
        //Scollegamento dall'evento attivato dal cambio di una scena.
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    
        //Funzione eseguita ad ogni caricamento di una nuova scena.
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //Se mi trovo nella scena dei Powerup, invoco la funzione che mostra a video i PowerUp.
            if (scene.name.Equals("Powerup"))
            {
                StartCoroutine(ChangeAnimationToDespawnAndShowPowerUp());
            }
        
            if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition") || scene.name.Equals("Powerup") || scene.name.Equals("EndGame")))
            {
                _player = FindObjectOfType<Player>();
            
                //Gestisce il powerUp IncreaseDamage
                if (increaseDmg.Active)
                {
                    if(_player != null)
                        _player.Damage = 2;
                
                    increaseDmg.Active = false;
                }
            
                //Il powerUp IncreaseHealth è gestito nel GameManager, per una scelta di progetto.
            
                //Gestisce il powerUp SlowTimer
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

        //Funzione che permette di gestire il flusso di animazioni a video del Powerup
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
}

using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Leo.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        //Healthbar del player.
        public Slider playerLifeSlider;
        
        //Variabili per associare lo "spawn" del projectile.
        public  GameObject originShooting;
        public  GameObject projectile;
        
        //OffSet
        private Vector3 offset = new Vector3(0.20f,0,0);
        
        //Bool per verificare se il player è morto(Game Over).
        public bool isPlayerDead;

        public bool IsPlayerDead
        {
            get => isPlayerDead;
        }
        
        //Funzione per gestire lo shooting del player.
        public  void ShotToEnemy()
        {
            //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
            Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
        }
        
        //Funzione per far gestire la morte del player.
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            playerLifeSlider.value = 0;
            LevelGameOver();
        }
        
        //Funzione per gestire il Game Over del livello;
        public void LevelGameOver()
        {
            isPlayerDead = true;
            //Set del levelOrigin nel livello appena completato.
            GameManager.Instance.LevelOriginIndex = GameManager.Instance.LevelDestinationIndex;
            SceneManager.LoadScene(0);
            
            Debug.Log("Il player è morto: "+ isPlayerDead);
        }
    }
}

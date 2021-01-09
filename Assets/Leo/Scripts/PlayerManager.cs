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
            //TODO settare la vita del player -1 se prende danni
            playerLifeSlider.value = 0;
        }
        

    }
}

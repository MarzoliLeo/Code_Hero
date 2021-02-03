using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Leo.Scripts
{
    public class Player : MonoBehaviour
    {
        //Vita da settare
        public int health;
        //Healthbar del player.
        public Slider playerLifeSlider;
        
        //Variabili per associare lo "spawn" del projectile.
        public  GameObject originShooting;
        public  GameObject projectile;
        public  ParticleSystem projectileEmitterPlayer;
        public ParticleSystem takingDamageEmitterPlayer;
        
        //OffSet
        private Vector3 offset = new Vector3(0.20f,0,0);
        
        //Bool per verificare se il player è morto(Game Over).
        public bool isPlayerDead;

        //Funzione per gestire lo shooting del player.
        public  void ShotToEnemy()
        {
            //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
            Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
            //Fa partire l'emmiters (particle system)
            projectileEmitterPlayer.Play();
        }
        
        //Funzione per far gestire la morte del player.
        private void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            //Mostra i cuori se prendi danno.
            takingDamageEmitterPlayer.Play();
            // Settare la vita del player -1 se prende danni
            var damage = other.GetComponent<ProjectileEnemy>().Damage;
            health -= damage;
            playerLifeSlider.value -= damage;
            if (health == 0)
            {
                isPlayerDead = true;
            }
        }
    }
}

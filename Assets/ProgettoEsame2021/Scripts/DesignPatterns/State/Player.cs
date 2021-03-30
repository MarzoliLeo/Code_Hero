using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace ProgettoEsame2021.Scripts
{
    public class Player : CharacterBase
    {
        //Questo damage e' definito solo sul Player poiche' serve per il PowerUp.
        private int damage = 1;

        public int Damage
        {
            get => damage;
            set => damage = value;
        }
        
        //Funzione per gestire lo shooting del player.
        public  override void Shoot()
        {
            if (canAttack)
            {
                //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
                Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
                //Riproduzione del sound
                AudioSource.PlayClipAtPoint(shootingSound,originShooting.transform.position,1);
                //Fa partire l'emmiters (particle system)
                projectileEmitter.Play();
            }
        }
        
        //Funzione per far gestire la morte del player.
        public override void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            //Mostra i cuori se prendi danno.
            takingDamageEmitter.Play();
            // Settare la vita del player -1 se prende danni
            var damage = other.GetComponent<ProjectileEnemy>().Damage;
            health -= damage;
            lifeSlider.value -= damage;
            if (health <= 0)
            {
                isDead = true;
            }
        }
    }
}

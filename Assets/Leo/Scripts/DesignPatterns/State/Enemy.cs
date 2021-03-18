﻿using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;

namespace Leo.Scripts
{
    public class Enemy : CharacterBase
    {
        
        //Funzione per gestire lo shooting del nemico.
        public override void Shoot()
        {
            if (canAttack)
            {
                //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
                Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
                AudioSource.PlayClipAtPoint(shootingSound, originShooting.transform.position, 1);
                //Fa partire l'emmiters (particle system)
                projectileEmitter.Play();
            }
        }

        //Funzione per far gestire la morte del nemico.
        public override void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            //Mostra i cuori se prendi danno.
            takingDamageEmitter.Play();
            // Settare la vita del player -1 se prende danni
            //var damage = other.GetComponent<ProjectilePlayer>().Damage;
            health -= FindObjectOfType<Player>().Damage;
            lifeSlider.value -= FindObjectOfType<Player>().Damage;

            if (health <= 0)
            {
                isDead = true;

            }
        }
        
    }
}

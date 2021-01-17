using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    //Vita da settare
    public int health;
    //Healthbar dell'enemy.
    public Slider enemyLifeSlider;

    //Variabili per associare lo "spawn" del projectile.
    public  GameObject originShooting;
    public  GameObject projectile;
    public  ParticleSystem projectileEmitterEnemy;
    
    //OffSet
    private Vector3 offset = new Vector3(-0.20f,0,0);
    
    //Bool per verificare se il nemico è morto (Victory).
    public bool isEnemyDead;

    public bool IsEnemyDead
    {
        get => isEnemyDead;
        set => isEnemyDead = value;
    }

    //Funzione per gestire lo shooting del nemico.
    public  void ShotToPlayer()
    {
        //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
        Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
        //Fa partire l'emmiters (particle system)
        projectileEmitterEnemy.Play();
    }

    //Funzione per far gestire la morte del nemico.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        // Settare la vita del player -1 se prende danni
        enemyLifeSlider.value -= other.GetComponent<ProjectilePlayer>().Damage;
    }


    
}

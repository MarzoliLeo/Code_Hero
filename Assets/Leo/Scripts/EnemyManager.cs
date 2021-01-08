using System;
using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    //Healthbar dell'enemy.
    public Slider enemyLifeSlider;
    
    //Variabili per associare lo "spawn" del projectile.
    public  GameObject originShooting;
    public  GameObject projectile;
    
    //OffSet
    private Vector3 offset = new Vector3(-0.20f,0,0);
    
    //Bool per verificare se il nemico è morto (Victory).
    public bool isEnemyDead;

    public bool IsEnemyDead
    {
        get => isEnemyDead;
    }
    
    //Funzione per gestire lo shooting del nemico.
    public  void ShotToPlayer()
    {
        //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
        Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
    }

    //Funzione per far gestire la morte del nemico.
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        enemyLifeSlider.value = 0;
        LevelVictory();
    }

    //Funzione per gestire la vittoria del livello;
    public void LevelVictory()
    {
        isEnemyDead = true;
        //Set del levelOrigin nel livello appena completato.
        GameManager.Instance.LevelOriginIndex = GameManager.Instance.LevelDestinationIndex;
        //Incrementiamo la destinazione del player.
        GameManager.Instance.LevelDestinationIndex++;
        SceneManager.LoadScene(0);
        
        Debug.Log("L'enemy è morto: "+isEnemyDead);
    }
    
}

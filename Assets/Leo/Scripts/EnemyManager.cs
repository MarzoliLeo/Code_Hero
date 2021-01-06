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
    public  Slider enemyLifeSlider;
    
    //Bool per verificare se il nemico è morto.
    public bool isEnemyDead;

    public bool IsEnemyDead
    {
        get => isEnemyDead;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        SceneManager.LoadScene(0);
    }
}

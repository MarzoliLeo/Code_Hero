using System.Collections;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private int health;
    
    // Start is called before the first frame update
    void Start()
    {
        SetHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Funzione per impostare la vita a seconda del livello.
    public void SetHealth()
    {
        health = GameManager.Instance.LevelOriginIndex;
        FindObjectOfType<Player>().playerLifeSlider.maxValue = health;
        FindObjectOfType<Player>().playerLifeSlider.value = health;
        //TODO per l'enemy la stessa cosa.
    }
}

using System;
using System.Collections.Generic;
using Leo.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class BoxManager : Singleton<BoxManager>
{
    //Creazione delle foglie
    IComponent increaseDmg = new PowerUp("Aumento Danni");
    IComponent increaseHealth = new PowerUp("Aumento Vita");
    IComponent slowTimer = new PowerUp("Rallentamento Timer");
    
    //Creazione dei components
    Box commonBox = new Box("Common",Box.BoxRarity.Common);
    Box rareBox = new Box("Rare",Box.BoxRarity.Rare); 
    Box legendaryBox = new Box( "Legendary",Box.BoxRarity.Legendary);

    
    //Attributi utili per l'implementazione nel gioco
    private EffectsManager _effectsManager;
    
    //Lista che contiene i Box da cui selezionare.
    List<Box> boxList = new List<Box>();
    
    //Raccoglie, per poi mostrare nel gioco, i box common/rare/legendary
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    private void Start()
    { 
        //commonBox = 1 powerup Random
        commonBox.AddComponent(increaseDmg);
        commonBox.AddComponent(increaseHealth);
        commonBox.AddComponent(slowTimer);
        
        //rareBox =   2 commonBox
        rareBox.AddComponent(commonBox);
        rareBox.AddComponent(commonBox);
        
        //legendaryBox = 1 rareBox + 1 commonBox
        legendaryBox.AddComponent(rareBox);
        legendaryBox.AddComponent(commonBox);

        //Aggiunge i box alla lista
        boxList.Add(commonBox);
        boxList.Add(rareBox);
        boxList.Add(legendaryBox);

        /*commonBox.Pick();
        rareBox.Pick();
        legendaryBox.Pick();*/

    }
    
    //Collegamento dall'evento
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    //Scollegamento dall'evento
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Controlla che non venga fatta nessuna inizializzazione nel menù o nella scena di transizione
        if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition")))
        {
            //Ferma il tempo di gioco
            Time.timeScale = 0;
            
            //
            _effectsManager = FindObjectOfType<EffectsManager>();
            if (_effectsManager != null)
            {
                _effectsManager.HideBoxQuestionAndTimer();
            }
            
            ShowPowerUp();
        }
    }
    
    //Metodo che seleziona un box e mostra i powerUp contenuti.
    private void ShowPowerUp()
    {
        Random rand = new Random();
        int index = rand.Next(0,boxList.Count);
        /*
        Debug.Log("Ho scelto il box in posizione: " + index);
        foreach (var b in boxList)
        {
            Debug.Log("La rarita dei box contenuta nella lista e': "+ b.Rarity);
        }*/
        boxList[index].Pick();
        
        Instantiate(box1, transform.position, Quaternion.identity);
    }

    
}

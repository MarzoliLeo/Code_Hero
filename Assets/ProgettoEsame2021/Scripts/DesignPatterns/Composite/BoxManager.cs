using System;
using System.Collections.Generic;
using ProgettoEsame2021.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class BoxManager : Singleton<BoxManager>
{
    private PoweUpManager _powerUpManager;
    
    //Creazione dei components
    Box commonBox = new Box("Common",Box.BoxRarity.Common);
    Box rareBox = new Box("Rare",Box.BoxRarity.Rare); 
    Box legendaryBox = new Box( "Legendary",Box.BoxRarity.Legendary);

    
    //Attributi utili per l'implementazione nel gioco
    private EffectsManager _effectsManager;
    
    //Lista che contiene i Box da cui selezionare.
    List<Box> boxList = new List<Box>();
    
    //Lista che contiene tutti gli Icomponent usciti dal box "pescato".
    List<IComponent> itemsInABox = new List<IComponent>();
    
    //Raccoglie, per poi mostrare nel gioco, i box common/rare/legendary
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;
    
    private static readonly int OpenBox = Animator.StringToHash("OpenBox");

    private void Start()
    {
        _powerUpManager = FindObjectOfType<PoweUpManager>();
        
        //commonBox = 1 powerup Random
        commonBox.AddComponent(_powerUpManager.increaseDmg);
        commonBox.AddComponent(_powerUpManager.increaseHealth);
        commonBox.AddComponent(_powerUpManager.slowTimer);
        
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
        //Controlliamo di essere nella Scena di PowerUp
        if (scene.name.Equals("Powerup"))
        {
            //Istanzia tutte le box nel gioco CHIUSE
            Instantiate(box1, transform.position, Quaternion.identity);
            Instantiate(box2, transform.position, Quaternion.identity);
            Instantiate(box3, transform.position, Quaternion.identity);
            
            ShowPowerUp();
        }
    }
    
    //Metodo che seleziona un box e mostra i powerUp contenuti.
    private void ShowPowerUp()
    {
        Random rand = new Random();
        int index = rand.Next(0,boxList.Count);
        
        boxList[index].Pick(ref itemsInABox);

        foreach (var item in itemsInABox)
        {
            //Todo trovare se possibile un modo per evitare di scrivere (Clone)
            if (item.Name.Equals("Common"))
            {
                //APRE ( a video ) il CommonBox se entra qui.
                GameObject.Find("CommonBox(Clone)").GetComponent<Animator>().SetBool("OpenBox",true);
            }
            else if (item.Name.Equals("Rare"))
            {
                //APRE ( a video ) il RareBox se entra qui.
                GameObject.Find("RareBox(Clone)").GetComponent<Animator>().SetBool("OpenBox",true);
            }
            else if (item.Name.Equals("Legendary"))
            {
                //APRE ( a video ) il LegendaryBox se entra qui.
                GameObject.Find("LegendaryBox(Clone)").GetComponent<Animator>().SetBool("OpenBox",true);
            }
            else
            {
                //Todo Allora è un powerUP se è qui dentro
            }
            
        }
       
    }

    
}

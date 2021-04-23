using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

namespace ProgettoEsame2021.Scripts.DesignPatterns.Composite
{
    public class BoxManager : Singleton<BoxManager>
    {
        //Riferimenti ad altre classi.
        private PowerUpManager _powerUpManager;
        private EffectsManager _effectsManager;
    
        //Creazione dei components (Box).
        Box commonBox = new Box("Common",Box.BoxRarity.Common);
        Box rareBox = new Box("Rare",Box.BoxRarity.Rare); 
        Box legendaryBox = new Box( "Legendary",Box.BoxRarity.Legendary);
        
        //Lista che contiene i Box su cui andremo ad operare.
        List<Box> boxList = new List<Box>();
    
        //Lista che contiene tutti gli Icomponent(altri Box oppure Powerup) usciti dal Box selezionato.
        List<IComponent> itemsInABox = new List<IComponent>();
    
        //Oggetti di gioco che si riferiscono ai Box: common/rare/legendary.
        public GameObject box1;
        public GameObject box2;
        public GameObject box3;
        
        //Funzione per inizializzare la variabili, viene richiamata al caricamento dello script, prima di tutte le altre.
        private void Start()
        {
            _powerUpManager = FindObjectOfType<PowerUpManager>();
        
            //commonBox = 3 powerup => Che risulterà in 1 Random.
            commonBox.AddComponent(_powerUpManager.increaseDmg);
            commonBox.AddComponent(_powerUpManager.increaseHealth);
            commonBox.AddComponent(_powerUpManager.slowTimer);
        
            //rareBox =   2 commonBox
            rareBox.AddComponent(commonBox);
            rareBox.AddComponent(commonBox);
        
            //legendaryBox = 1 rareBox + 1 commonBox => quindi 3 commonBox
            legendaryBox.AddComponent(rareBox);
            legendaryBox.AddComponent(commonBox);

            //Aggiunge i box alla lista
            boxList.Add(commonBox);
            boxList.Add(rareBox);
            boxList.Add(legendaryBox);
        
        }
    
        //Collegamento dall'evento attivato dal cambio di una scena.
        private void OnEnable()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    
        //Scollegamento dall'evento attivato dal cambio di una scena.
        private void OnDisable()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        //Funzione associato all'evento.
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //Controlliamo di essere nella scena di PowerUp
            if (scene.name.Equals("Powerup"))
            {
                //Istanzia tutte le box nel gioco CHIUSE, verranno poi animate.
                Instantiate(box1, transform.position, Quaternion.identity);
                Instantiate(box2, transform.position, Quaternion.identity);
                Instantiate(box3, transform.position, Quaternion.identity);
            
                ShowPowerUp();
            }
        }
    
        //Funzione che seleziona un box e mostra i powerUp contenuti, iterando il contenuto del box preso.
        private void ShowPowerUp()
        {
            //Prende un box dalla lista "boxList" [0] = common, [1] = rare, [2] = legendary.
            Random rand = new Random();
            int index = rand.Next(0,boxList.Count);
        
            //Itera il box e il suo contenuto e riempie la lista "itemsInABox" con tutto ciò che c'era dentro.
            boxList[index].Pick(ref itemsInABox);

            foreach (var item in itemsInABox)
            {
                if (item.Name.Equals("Common"))
                {
                    //APRE ( a video, con una animazione ) il CommonBox se entra qui.
                    GameObject.Find("CommonBox(Clone)").GetComponent<Animator>().SetBool("OpenBox",true);
                }
                else if (item.Name.Equals("Rare"))
                {
                    //APRE ( a video, con una animazione ) il RareBox se entra qui.
                    GameObject.Find("RareBox(Clone)").GetComponent<Animator>().SetBool("OpenBox",true);
                }
                else if (item.Name.Equals("Legendary"))
                {
                    //APRE ( a video, con una animazione ) il LegendaryBox se entra qui.
                    GameObject.Find("LegendaryBox(Clone)").GetComponent<Animator>().SetBool("OpenBox",true);
                }
            }
        }
    }
}

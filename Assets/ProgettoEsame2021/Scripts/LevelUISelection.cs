using UnityEngine;
using UnityEngine.UI;

namespace ProgettoEsame2021.Scripts
{
    public class LevelUISelection : MonoBehaviour
    {
        //Riferimento al testo dell'UI.
        public Text levelText;
        //Riferimento al bottone Start.
        public GameObject buttonStartLevel;
    
        //Funzione per l'inizializzazione delle variabili.
        void Start()
        {
            SetActiveButton(false);
        }
    
        //Funzione per "Settare" nell' UI del gioco il testo che mostra il livello in cui si è.
        public void SetLevelText(string text)
        {
            levelText.text = text; 
        }

        //Funzione per mostrare o disabilitare il bottone di Start(Nel gioco).
        public void SetActiveButton(bool isActive)
        {
            buttonStartLevel.SetActive(isActive);
        }
    }
}

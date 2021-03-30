using UnityEngine;

namespace ProgettoEsame2021.Scripts
{
    //Classe per la gestione degli effetti visivi nel gioco.
    public class EffectsManager : MonoBehaviour
    {
        //Riferimenti agli oggetti nel gioco.
        public GameObject canvasOfBoxQuestion;
        public GameObject victoryText;
        public GameObject gameOverText;
        public GameObject canvasSliderTimer;

        //Riferimenti alle classi.
        private Player _playerRef;
        private Enemy _enemyRef;
        
        //La Funzione Start verrà chiamato appena lo script sarà caricato, prima di qualsiasi altro metodo.
        //Funzione per l'inizializzazione delle variabili.
        private void Start()
        {
            _playerRef = FindObjectOfType<Player>();
            _enemyRef = FindObjectOfType<Enemy>();
            
            InitializeCanvases();
        }
        
        //Funzione per inizializzare la visibilità degli oggetti ad inizio gioco.
        public void InitializeCanvases()
        {
            canvasOfBoxQuestion.SetActive(true);
            canvasSliderTimer.SetActive(true);
            
            victoryText.SetActive(false);
            gameOverText.SetActive(false);
        }

        //Funzione per mostrare a video il riquadro delle domande con le risposte e la barra del timer.
        public void ShowBoxQuestionAndTimer()
        {
            canvasOfBoxQuestion.SetActive(true);
            canvasSliderTimer.SetActive(true);
        }
        
        //Funzione per nascondere il riquadro delle domande con le risposte e la barra del timer.
        public void HideBoxQuestionAndTimer()
        {
            canvasOfBoxQuestion.SetActive(false);
            canvasSliderTimer.SetActive(false);
        }
    
        //Funzione per mostrare la Vittoria.
        public void ShowVictoryText()
        {
            victoryText.SetActive(true);
        }

        //Metodo per mostrare il Game Over.
        public void ShowGameOverText()
        {
            gameOverText.SetActive(true);
        }

    }
}

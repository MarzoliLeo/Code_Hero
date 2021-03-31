using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ProgettoEsame2021.Scripts
{
    public class TimerCountdown : MonoBehaviour
    {
        //Oggetti del gioco per gestire la barra del tempo.
        public Slider timeToAnswer;
        public GameObject timeRemaining;
        private Image _image;
    
        private int sliderToBecomeYellow = 6;
        private int sliderToBecomeRed = 3;
    
        //Variabile per stabilire la velocità del tempo a scalare.
        public float speedOfTime = 1f;
    
        //Riferimenti ad altre classi.
        private EffectsManager _effectsManager;
    
        //Funzione che inizilizza le variabili e viene eseguita non appena lo script è caricato.
        private void Start()
        {
            _effectsManager = FindObjectOfType<EffectsManager>();
            _image = timeRemaining.GetComponent<Image>();
        }

        //Funzione che viene eseguita ogni frame del gioco.
        private void Update()
        {
            timeToAnswer.value -= Time.deltaTime * speedOfTime;

            //Impostazione del colore del tempo in base al tempo mancante
            if (timeToAnswer.value > sliderToBecomeRed  &&  timeToAnswer.value < sliderToBecomeYellow)
            {
                _image.color = Color.yellow;
            }
            else if (timeToAnswer.value < sliderToBecomeRed)
            {
                _image.color = Color.red;
            }
            else
            {
                _image.color = Color.green;
            }
        
            if (timeToAnswer.value < Mathf.Epsilon)
            {
                if (GameManager.Instance.TextPlaying == false)
                {
                    //Gestisce il GameOver dovuto allo scadere del tempo.
                    _effectsManager.HideBoxQuestionAndTimer();
                    _effectsManager.ShowGameOverText();
                
                    //Set del levelOrigin nel livello appena raggiunto(Try Again).
                    GameManager.Instance.LevelOriginIndex = GameManager.Instance.LevelDestinationIndex;
                
                    //Ricarica il menù di selezione del livello, dopo un certo delay.
                    Invoke("LoadMainMap", 5);
                }
            }
        }
    
        //Funzione che permette di cambiare scena e in particolare ritorna a quella 0 (menù)
        public void LoadMainMap()
        {
            SceneManager.LoadScene(0);
        }
    }
}

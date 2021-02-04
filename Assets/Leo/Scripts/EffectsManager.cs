using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leo.Scripts
{
    public class EffectsManager : MonoBehaviour
    {
        public GameObject canvasOfBoxQuestion;
        public GameObject victoryText;
        public GameObject gameOverText;
        public GameObject canvasSliderTimer;

        private Player _playerRef;
        private Enemy _enemyRef;
        
        private void Start()
        {
            _playerRef = FindObjectOfType<Player>();
            _enemyRef = FindObjectOfType<Enemy>();
            
            canvasOfBoxQuestion.SetActive(true);
            canvasSliderTimer.SetActive(true);
            victoryText.SetActive(false);
            gameOverText.SetActive(false);
        }
        
        //Metodo per nascondere il box delle domande con le risposte.
        public void HideBoxQuestionAndTimer()
        {
            canvasOfBoxQuestion.SetActive(false);
            canvasSliderTimer.SetActive(false);
        }
    
        //Metodo per mostrare il testo di Victory, se si vince.
        public void ShowVictoryText()
        {
            victoryText.SetActive(true);
        }

        //Metodo per mostrare il testo di Game Over,se si perde.
        public void ShowGameOverText()
        {
            gameOverText.SetActive(true);
        }

    }
}

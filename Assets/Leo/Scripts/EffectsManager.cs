using UnityEngine;

namespace Leo.Scripts
{
    public class EffectsManager : MonoBehaviour
    {
        public GameObject canvasOfBoxQuestion;
        public GameObject victoryText;
        public GameObject gameOverText;

        private Player _playerRef;
        private Enemy _enemyRef;
        
        private void Start()
        {
            _playerRef = FindObjectOfType<Player>();
            _enemyRef = FindObjectOfType<Enemy>();
            
            canvasOfBoxQuestion.SetActive(true);
            victoryText.SetActive(false);
            gameOverText.SetActive(false);
        }

        private void Update()
        {
            if (_enemyRef.isEnemyDead)
            {
                HideBoxQuestion();
                ShowVictoryText();
            }
            if (_playerRef.isPlayerDead)
            {
                HideBoxQuestion();
                ShowGameOverText();
            }
        }

        //Metodo per nascondere il box delle domande con le risposte.
        public void HideBoxQuestion()
        {
            canvasOfBoxQuestion.SetActive(false);
        }
    
        //Metodo per mostrare il testo di vittoria, se si vince.
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

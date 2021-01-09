using System.Collections;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Leo.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        //
        private int _levelDestinationIndex;
        private int _levelOriginIndex;
        
        //Riferimento ai player ed enemy del Livello.(1)
        private PlayerManager _playerManagerRef;
        private EnemyManager _enemyManagerRef;
        
        //Riferimento al QuestioManager
        private QuestionManager _questionManager;
        
        //
        private Waypoint destinationWaypoint;

        public Waypoint DestinationWaypoint
        {
            get => destinationWaypoint;
            set => destinationWaypoint = value;
        }

        public int LevelOriginIndex
        {
            get => _levelOriginIndex;
            set => _levelOriginIndex = value;
        }
    
        public int LevelDestinationIndex
        {
            get => _levelDestinationIndex;
            set => _levelDestinationIndex = value;
        }
        
                
        //Collegamento dall'evento
        private void OnEnable()
        {
            AnswerController.onCheckAnswerEvent += OnAnswerEvaluation;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        //Scollegamento dall'evento
        private void OnDisable()
        {
            AnswerController.onCheckAnswerEvent -= OnAnswerEvaluation;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void Start()
        {
            LevelOriginIndex = 1;
            LevelDestinationIndex = 1;
        }

        public void OnAnswerEvaluation(bool value)
        {
            if (value)
            {
                //Il player spara all'enemy
                _playerManagerRef.ShotToEnemy();
            }
            else
            {
                //L'enemy spara al player
                _enemyManagerRef.ShotToPlayer();
            }
            
            // Controlla se ci sono ancora domande nel QuestioManager(QuestioLevel)
            if (_questionManager.CountQuestions() == 0)
            {
                //TODO Pensare come fare la fine.
                LevelVictory();
            }
            else
            {
                _questionManager.DisplayQuestion();
                
            }
        }
        
        //Evento del SceneManager interno.
        private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
        {
            Debug.Log("Scena: " + scene.name);
            _playerManagerRef = FindObjectOfType<PlayerManager>();
            _enemyManagerRef = FindObjectOfType<EnemyManager>();
            _questionManager = FindObjectOfType<QuestionManager>();
        }
        
        
        //Funzione per gestire la vittoria del livello;
        public void LevelVictory()
        {
            //TODO isEnemyDead = true;
            //Set del levelOrigin nel livello appena completato.
            LevelOriginIndex = LevelDestinationIndex;
            //Incrementiamo la destinazione del player.
            LevelDestinationIndex++;
            SceneManager.LoadScene(0);
        
            //Debug.Log("L'enemy è morto: "+isEnemyDead);
        }
        
        //Funzione per gestire il Game Over del livello;
        public void LevelGameOver()
        {
            //TODO isPlayerDead = true;
            //Set del levelOrigin nel livello appena completato.
            LevelOriginIndex = LevelDestinationIndex;
            SceneManager.LoadScene(0);
            
            //Debug.Log("Il player è morto: "+ isPlayerDead);
        }
    }
}

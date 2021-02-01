using System;
using System.Collections;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Leo.Scripts
{
    public class GameManager : Singleton<GameManager>
    {

        
        //Start Combat Music
        private SoundManager _soundManager;
        
        //
        private int _levelDestinationIndex;
        private int _levelOriginIndex;
        
        //
        private bool _drawMode;
        
        //Riferimento ai player ed enemy del Livello.(1)
        private Player _playerRef;
        private Enemy _enemyRef;
        
        //Riferimento al QuestioManager
        private QuestionManager _questionManager;
        
        //Riferimento all'EffectManager
        private EffectsManager _effectsManager;
        
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
                _playerRef.ShotToEnemy();
            }
            else
            {
                //L'enemy spara al player
                _enemyRef.ShotToPlayer();
            }
            
            // Controlla se ci sono ancora domande nel QuestioManager(QuestioLevel)
            if (_questionManager.CountQuestions() == 0)
            {
                //TODO Sistemare il draw Sistem.
                //Todo problema: entra sempre nel draw perchè il proiettile non ha il tempo di portare la vita a 0 del player o dell'enemy,
                //perciò entra sempre in LevelDraw();
                if (_enemyRef.isEnemyDead)
                {
                    LevelVictory();
                }
                else if (_playerRef.isPlayerDead)
                {
                    LevelGameOver();
                }
                else
                {
                    LevelDraw();
                }
            }
            else
            {
                _questionManager.DisplayQuestion();
                
            }
        }
        
        //Evento del SceneManager interno.
        private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
        {
            //Controlla che non venga fatta nessuna inizializzazione nel menù
            if (scene.buildIndex != 0 || scene.buildIndex != 4)
            {
                
                _playerRef = FindObjectOfType<Player>();
                _enemyRef = FindObjectOfType<Enemy>();
                _soundManager = FindObjectOfType<SoundManager>();
                _questionManager = FindObjectOfType<QuestionManager>();
                _effectsManager = FindObjectOfType<EffectsManager>();

                
                _soundManager.PlayFightSound();
                //Setta la vita del player in base al livello.
                _playerRef.health = LevelOriginIndex;
            
                _playerRef.playerLifeSlider.maxValue += _playerRef.health ;
                _playerRef.playerLifeSlider.value = _playerRef.playerLifeSlider.maxValue;
                
                //Setta la vita dell'enemy in base al livello.
                _enemyRef.health = LevelOriginIndex;
            
                _enemyRef.enemyLifeSlider.maxValue += _enemyRef.health ;
                _enemyRef.enemyLifeSlider.value = _enemyRef.enemyLifeSlider.maxValue;
                
            }
            else
            {
               // _soundManager.StopFightSound();
            }

        }
        
        
        //Funzione per gestire la vittoria del livello;
        private void LevelVictory()
        {

                _effectsManager.HideBoxQuestionAndTimer();
                _effectsManager.ShowVictoryText();
                //Set del levelOrigin nel livello appena completato.
                LevelOriginIndex = LevelDestinationIndex;
                //Incrementiamo la destinazione del player.
                LevelDestinationIndex++;
                Invoke("LoadLevelSelectionMap",5/*0.6f*/);
                
                Debug.Log("Sono Dentro LevelVictory");
            
        }
        
        //Funzione per gestire il Game Over del livello;
        private void LevelGameOver()
        {

                _effectsManager.HideBoxQuestionAndTimer();
                _effectsManager.ShowGameOverText();
                //Set del levelOrigin nel livello appena raggiunto(ritentare).
                LevelOriginIndex = LevelDestinationIndex;
                Invoke("LoadLevelSelectionMap",5/*0.6f*/);
                
                Debug.Log("Sono Dentro GameOver");
        }
        
        //Funzione per gestire lo stato di Draw nel caso in cui l'enemy o il player non muoiano.
        private void LevelDraw()
        {
            _effectsManager.HideBoxQuestionAndTimer();
            _effectsManager.ShowDrawText();
            //Set del levelOrigin nel livello appena raggiunto(ritentare).
            LevelOriginIndex = LevelDestinationIndex;
            Invoke("LoadLevelSelectionMap",5/*0.6f*/);
            
            Debug.Log("Sono Dentro Draw");
        }

        public void LoadLevelSelectionMap()
        {
            SceneManager.LoadScene(0);
        }
    }
}

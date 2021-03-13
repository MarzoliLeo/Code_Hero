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
        //
        private bool onlyOneLevelVictoryGameOver;
        
        //
        private bool tutorialExplained;

        //Variabile per il corretto controllo per mostrare i testi di: Victory & GameOver
        private bool textPlaying;

        //
        private bool _drawMode = false;
        private const float timeToWait = 0.7f;
        
        //Start Combat Music
        private SoundManager _soundManager;
        
        //
        private int _levelDestinationIndex;
        private int _levelOriginIndex;
        
        
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
        
        public bool TextPlaying
        {
            get => textPlaying;
            set => textPlaying = value;
        }
        
        public bool TutorialExplained
        {
            get => tutorialExplained;
            set => tutorialExplained = value;
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
        
        //Controllo continuamente se il player o l'enemy sono morti prima del finire delle domande.
        private void Update()
        {
            //Todo deve partire una sola couritine sennò spamma il ricarimento del menù.
            
            if (_enemyRef != null && _playerRef != null && _effectsManager != null)
            {
                if (_enemyRef.isDead && !onlyOneLevelVictoryGameOver)
                {
                    onlyOneLevelVictoryGameOver = true;

                    StartCoroutine(LevelVictory());
                }
                else if (_playerRef.isDead && !onlyOneLevelVictoryGameOver)
                {
                    onlyOneLevelVictoryGameOver = true;
                    _effectsManager.HideBoxQuestionAndTimer();
                    
                    StartCoroutine(LevelGameOver());
                }
                //altrimenti continui ad eseguire.
            }
        }

        public void OnAnswerEvaluation(bool value)
        {
            if (value)
            {
                //Impostazione del booleano ereditato dalla classe base.
                _playerRef.canAttack = true;
                //Il player spara all'enemy
                //_playerRef.Shoot();
            }
            else
            {
                //Impostazione del booleano ereditato dalla classe base.
                _enemyRef.canAttack = true;
                //L'enemy spara al player
                //_enemyRef.Shoot();
            }
            
            // Controlla se ci sono ancora domande nel QuestioManager(QuestioLevel)
            if (_questionManager.CountQuestions() == 0)
            {
                //se sono finite le domande hai perso.
                StartCoroutine(LevelGameOver());
            }
            else
            {
                _questionManager.DisplayQuestion();
                
            }
        }
        
        //Evento del SceneManager interno.
        private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
        {
            //Controlla che non venga fatta nessuna inizializzazione nel menù o nella scena di transizione
            if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition") || scene.name.Equals("Powerup")))
            {
                //Reimpostare il boleano per la valutazione del isPlayerDead o isEnemyDead
                onlyOneLevelVictoryGameOver = false;
                
                //Reimpostato la condizione del testo a false, in modo da resettarla per ogni livello.
                GameManager.Instance.TextPlaying = false;
                
                //
                _playerRef = FindObjectOfType<Player>();
                _enemyRef = FindObjectOfType<Enemy>();
                _questionManager = FindObjectOfType<QuestionManager>();
                _effectsManager = FindObjectOfType<EffectsManager>();

                //Setta la vita del player in base al livello.
                if (_playerRef != null)
                {
                    _playerRef.health = DestinationWaypoint.levelIndex;
            
                    _playerRef.lifeSlider.maxValue = _playerRef.health ;
                    _playerRef.lifeSlider.value = _playerRef.lifeSlider.maxValue;
                }

                if (_enemyRef != null)
                {
                    //Setta la vita dell'enemy in base al livello.
                    _enemyRef.health = DestinationWaypoint.levelIndex;
            
                    _enemyRef.lifeSlider.maxValue = _enemyRef.health ;
                    _enemyRef.lifeSlider.value = _enemyRef.lifeSlider.maxValue;
                }
            }
        }
        
        
        //Funzione per gestire la vittoria del livello;
        IEnumerator LevelVictory()
        {
            //Todo sistemare il fatto che quando rispondi alla prima domanda mostra la seconda domanda con calma.
            _effectsManager.HideBoxQuestionAndTimer();
            yield return new WaitForSeconds(timeToWait);
            if (_enemyRef.isDead)
            {
                textPlaying = true;
                _drawMode = false;
                
                _effectsManager.ShowVictoryText();
                //Set del levelOrigin nel livello appena completato.
                LevelOriginIndex = LevelDestinationIndex;
                //Incrementiamo la destinazione del player.
                LevelDestinationIndex++;
                Invoke("LoadLevelSelectionMap",5);

            }
            else
            {
                _drawMode = true;
            }
        }
        
        //Funzione per gestire il Game Over del livello;
        IEnumerator LevelGameOver()
        {
            _effectsManager.HideBoxQuestionAndTimer();
            yield return new WaitForSeconds(timeToWait + 0.05f);
            if (_playerRef.isDead || _drawMode)
            {
                textPlaying = true;
                
                _effectsManager.ShowGameOverText();
                //Set del levelOrigin nel livello appena raggiunto(ritentare).
                LevelOriginIndex = LevelDestinationIndex;
                //Todo fare una variabile per il time.
                Invoke("LoadLevelSelectionMap",5);
            }
        }

        public void LoadLevelSelectionMap()
        {
            SoundManager.Instance.StopFightSound();
            SceneManager.LoadScene(0);
        }
        

    }
}

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
        private bool textPlaying;

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
                StartCoroutine(LevelVictory());
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
            //Controlla che non venga fatta nessuna inizializzazione nel menù
            if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition")))
            {
                
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
            yield return new WaitForSeconds(timeToWait);
            if (_enemyRef.isDead)
            {
                textPlaying = true;
                _drawMode = false;
                _effectsManager.HideBoxQuestionAndTimer();
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
            yield return new WaitForSeconds(timeToWait + 0.05f);
            if (_playerRef.isDead || _drawMode)
            {
                textPlaying = true;
                _effectsManager.HideBoxQuestionAndTimer();
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

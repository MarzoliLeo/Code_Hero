using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProgettoEsame2021.Scripts
{
    //Classe che gestisce tutte le dinamiche principali del gioco.
    public class GameManager : Singleton<GameManager>
    {
        //Variabili  per evitare che la modalità Victory o Game Over si sovrappongano.
        private bool onlyOneLevelVictoryGameOver;
        private bool textPlaying;
        
        //Variabile per stabilire se il tutorial è stato eseguito.
        private bool tutorialExplained;
        
        //Variabile per stabilire se c'è stato un pareggio.
        private bool _drawMode = false;
        
        //Costante di attesa per effettuare la valutazione di alcune operazioni.
        private const float timeToWait = 0.7f;
        
        //Variabili per la progressione dei livelli.
        private int _levelDestinationIndex = 1;
        private int _levelOriginIndex = 1;
        
        //Riferimenti alle classi
        private Player _playerRef;
        private Enemy _enemyRef;
        private SoundManager _soundManager;
        private QuestionManager _questionManager;
        private EffectsManager _effectsManager;
        private Waypoint destinationWaypoint;

        //Propietà
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
        
                
        //Funzione per collegarsi agli eventi.
        private void OnEnable()
        {
            AnswerController.onCheckAnswerEvent += OnAnswerEvaluation;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        //Funzione per scollegarsi dagli eventi.
        private void OnDisable()
        {
            AnswerController.onCheckAnswerEvent -= OnAnswerEvaluation;
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        
        //La funzione Update viene richiamata ad ogni Frame del gioco.
        private void Update()
        {
            //Controllo se i riferimenti non sono nulli.
            if (_enemyRef != null && _playerRef != null && _effectsManager != null)
            {
                //Se il livello in cui ci troviamo e' il finale (quindi il 5° Waypoint), allora...
                if (DestinationWaypoint.levelIndex == 5)
                {
                    if (_enemyRef.isDead && !onlyOneLevelVictoryGameOver)
                    {
                        onlyOneLevelVictoryGameOver = true;
                        //... viene richiamata una vittoria "diversa".
                        StartCoroutine(FinalLevelVictory());
                    }
                    else if (_playerRef.isDead && !onlyOneLevelVictoryGameOver)
                    {
                        onlyOneLevelVictoryGameOver = true;
                        _effectsManager.HideBoxQuestionAndTimer();
                        
                        StartCoroutine(LevelGameOver());
                    }
                }//... altrimenti siamo in un livello normale.
                else
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
                }
            }
        }

        //Funzione attaccata all'evento, che valuta la risposta premuta e agisce di conseguenza.
        public void OnAnswerEvaluation(bool value)
        {
            if (value)
            {
                _playerRef.canAttack = true;
            }
            else
            {
                _enemyRef.canAttack = true;
            }
            
            // Controlla se le domande sono terminate.
            if (_questionManager.CountQuestions() == 0)
            {
                //se sono finite le domande viene richiamato il GameOver.
                StartCoroutine(LevelGameOver());
            }
            else
            {
                //altrimenti mostra un'altra domanda.
                _questionManager.DisplayQuestion();
                
            }
        }
        
        //Funzione interna al SceneManager che opera come Evento e viene richiamato ogni volta che si carica una nuova scena.
        private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
        {
            //Evita che le inizializzazioni vengano fatte nelle scene al di fuori dei livelli di gioco.
            if (!(scene.name.Equals("LevelSelectionMap") || scene.name.Equals("LoadingTransition") || scene.name.Equals("Powerup") || scene.name.Equals("EndGame")))
            {
                //Reset della var. per la valutazione della Vittoria o del Game Over di un livello.
                onlyOneLevelVictoryGameOver = false;
                TextPlaying = false;
                
                //Inizializzazione delle variabili, ripetuto per ogni livello.
                _playerRef = FindObjectOfType<Player>();
                _enemyRef = FindObjectOfType<Enemy>();
                _questionManager = FindObjectOfType<QuestionManager>();
                _effectsManager = FindObjectOfType<EffectsManager>();

                SetHealthGame();
            }
        }
        
       //Funzione per impostare correttamente la vita in base al livello e secondo il PowerUp.
        public void SetHealthGame()
        {
            //Setta la vita del player in base al livello, se il powerUp è attivo...
            if (_playerRef != null && PoweUpManager.Instance.increaseHealth.Active)
            {
                //La vita base è uguale al livello in cui si è + 1 per il powerUp.
                _playerRef.health = DestinationWaypoint.levelIndex + 1;
            
                //Aggiornato il valore della barra della vita nel gioco.
                _playerRef.lifeSlider.maxValue = _playerRef.health;
                _playerRef.lifeSlider.value = _playerRef.lifeSlider.maxValue;
                
                //Reset del powerUp per evitare il perdurarsi nei livelli.
                PoweUpManager.Instance.increaseHealth.Active = false;

            }
            else //... se il powerUp non e' attivo.
            {
                _playerRef.health = DestinationWaypoint.levelIndex;
            
                _playerRef.lifeSlider.maxValue = _playerRef.health ;
                _playerRef.lifeSlider.value = _playerRef.lifeSlider.maxValue;
            }
            
            //Setta la vita dell'enemy in base al livello.
            if (_enemyRef != null)
            {
                
                _enemyRef.health = DestinationWaypoint.levelIndex;
            
                _enemyRef.lifeSlider.maxValue = _enemyRef.health ;
                _enemyRef.lifeSlider.value = _enemyRef.lifeSlider.maxValue;
            }
        }
        
        //Funzione per gestire la vittoria del livello;
        IEnumerator LevelVictory()
        {
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
                
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene(0);
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
                //Set del levelOrigin nel livello appena raggiunto(Try Again).
                LevelOriginIndex = LevelDestinationIndex;
                
                yield return new WaitForSeconds(5);
                SceneManager.LoadScene(0);
            }
        }
    
        //Funzione per gestire la vittoria nell'ultimo livello e finire il gioco.
        IEnumerator FinalLevelVictory()
        {
            _effectsManager.HideBoxQuestionAndTimer();
            
            yield return new WaitForSeconds(timeToWait);
            
            textPlaying = true;
            _drawMode = false;
                
            _effectsManager.ShowVictoryText();
            
            yield return new WaitForSeconds(5);
            
            //Carica l'ultima scena.
            SceneManager.LoadScene("EndGame");
        }
        
    }
}

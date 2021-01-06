using System.Collections;
using UnityEngine;
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
        }

        //Scollegamento dall'evento
        private void OnDisable()
        {
            AnswerController.onCheckAnswerEvent -= OnAnswerEvaluation;
        }

        private void Start()
        {
            LevelOriginIndex = 1;
            LevelDestinationIndex = 1;
        }

        public void OnAnswerEvaluation(bool value)
        {
            StartCoroutine(SetTheVariables());
            
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
        }

        //Coroutine per inizializzare il valore di playerShootRef direttamente nel rispettivo livello.
        IEnumerator SetTheVariables()
        {
            _playerManagerRef = FindObjectOfType<PlayerManager>();
            _enemyManagerRef = FindObjectOfType<EnemyManager>();
            yield return new WaitForSeconds(1);
        }
    }
}

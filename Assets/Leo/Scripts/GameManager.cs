using UnityEngine;
using UnityEngine.UI;

namespace Leo.Scripts
{
    public class GameManager : Singleton<GameManager>
    {
        private int _levelDestinationIndex;
        private int _levelOriginIndex;

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
            if (value)
            {
                //TODO player.ShotToEnemy();
                Debug.Log("player.ShotToEnemy()");
            }
            else
            {
                //TODO enemy.ShotToPlayer();
                Debug.Log("enemy.ShotToPlayer()");
            }
        }
    }
}

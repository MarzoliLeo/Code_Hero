using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace Leo.Scripts
{
    public class LevelSelectionMap : MonoBehaviour
    {
        private Waypoint _waypoint;
        public GameObject playerToMove;               //sprite da muovere.

        private Vector3 offsetPosition = new Vector3(0.1f, 0.5f, 0);  //offset

        private float characterSpeed = 3; //Velocità di movimento del player da un waypoint ad un altro.
        private bool movePlayer;
        private bool isLevelReached;

        private GameManager _gameManager;
        private WaypointManager _waypointManager;
        private UIManager _uiManager;
        
    
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
            _waypointManager = GameObject.FindObjectOfType<WaypointManager>();
            _uiManager = GameObject.FindObjectOfType<UIManager>();
        }

        private void Update()
        {
            MovePlayerInTheMap();
        }

        //Funzione che muove il player lungo i waypoints nella mappa in maniera fluida.
        private void MovePlayerInTheMap()
        {
            if (!movePlayer) { return; }
            transform.position = Vector3.MoveTowards(playerToMove.transform.position,
                _waypointManager.Waypoints[_waypointManager.DestinationIndex].transform.position + offsetPosition, Time.deltaTime * characterSpeed);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_waypointManager.DestinationIndex < _waypointManager.Waypoints.Count - 1)
            {
                _waypointManager.DestinationIndex++;
            }
            
            movePlayer = false;
            Waypoint waypointComponent = other.GetComponent<Waypoint>();

            if (waypointComponent != null)
            {
                _uiManager.SetLevelText("Level " + waypointComponent.levelIndex.ToString());
                
                if (waypointComponent.levelIndex == _gameManager.LevelDestination)
                {
                    _uiManager.SetActiveButton(true);
                    isLevelReached = true;
                }
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (!isLevelReached)
            {
                movePlayer = true;
            }
        }
    
        //Funzione per settare la posizione del player alla starting Position.
        public void SetStartPosition(Vector3 startPos)
        {
            playerToMove.transform.position = startPos + offsetPosition;
        }
    }
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using System.Linq;

namespace Leo.Scripts
{
    public class PlayerMoveMap : MonoBehaviour
    {
        private Waypoint _waypoint;
        public GameObject playerToMove;                                //sprite da muovere.
        public List<GameObject> waypoints = new List<GameObject>();    //Lista che contiene i waypoints.

        private Vector3 offsetPosition = new Vector3(0.1f, 0.5f, 0);  //offset

        private float characterSpeed = 3; //Velocità di movimento del player da un waypoint ad un altro.
        private bool movePlayer;
        private bool isLevelReached;

        private int currentIndex;
        private int destinationIndex;

        private GameManager _gameManager;
    
        // Start is called before the first frame update
        void Start()
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
            foreach (var i in waypoints)
            {
                if (i.GetComponent<Waypoint>() != null)
                {
                    if (i.GetComponent<Waypoint>().levelIndex == _gameManager.LevelOrigin)
                    {
                        currentIndex = waypoints.FindIndex(w =>
                        {
                            return i.name.Equals(w.name);
                        });
                        playerToMove.transform.position = waypoints[currentIndex].transform.position + offsetPosition;
                        destinationIndex = currentIndex;
                    }
                }
            }
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
                    waypoints[destinationIndex].transform.position + offsetPosition, Time.deltaTime * characterSpeed);
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (destinationIndex < waypoints.Count - 1)
            {
                destinationIndex++;
            }
            
            movePlayer = false;
            Waypoint waypointComponent = other.GetComponent<Waypoint>();

            if (waypointComponent != null)
            {
                if (waypointComponent.levelIndex == _gameManager.LevelDestination)
                {
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
    }
}

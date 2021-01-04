using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Leo.Scripts
{
    public class WaypointManager : MonoBehaviour
    {


        public List<GameObject> waypoints = new List<GameObject>();    //Lista che contiene i waypoints.
        
        private GameManager _gameManager;
        private LevelSelectionMap _levelSelectionMap;
        
        private int currentIndex;
        private int destinationIndex;

        private Waypoint destinationWaypoint;

        //props.
        public int CurrentIndex
        {
            get => currentIndex;
            set => currentIndex = value;
        }

        public int DestinationIndex
        {
            get => destinationIndex;
            set => destinationIndex = value;
        }
        
        public Waypoint DestinationWaypoint
        {
            get => destinationWaypoint;
        }
        

        //Readyonly prop.
        public List<GameObject> Waypoints
        {
            get => waypoints;
        }

        private void Start()
        {
            _gameManager = GameObject.FindObjectOfType<GameManager>();
            _levelSelectionMap = GameObject.FindObjectOfType<LevelSelectionMap>();
            
            //Facciamo ritornare il player una volta terminato il livello nella posizione di origine.
            foreach (var i in Waypoints)
            {
                if (i.GetComponent<Waypoint>() != null)
                {
                    if (i.GetComponent<Waypoint>().levelIndex == _gameManager.LevelOrigin)
                    {
                        currentIndex = Waypoints.FindIndex(w =>
                        {
                            return i.name.Equals(w.name);
                        });
                        _levelSelectionMap.SetStartPosition(Waypoints[currentIndex].transform.position);
                        destinationIndex = currentIndex;
                    }

                    if (i.GetComponent<Waypoint>().levelIndex == _gameManager.LevelDestination)
                    {
                        destinationWaypoint = i.GetComponent<Waypoint>();
                    }
                }
            }
        }
    }
}

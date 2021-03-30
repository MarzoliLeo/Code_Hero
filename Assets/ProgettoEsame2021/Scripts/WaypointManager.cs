﻿using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ProgettoEsame2021.Scripts
{
    public class WaypointManager : MonoBehaviour
    {
        
        public List<GameObject> waypoints = new List<GameObject>();    //Lista che contiene i waypoints.
        
        private GameManager _gameManager;
        private LevelSelectionMap _levelSelectionMap;
        
        private int currentIndex;
        private int destinationIndex;

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


        //Readyonly prop.
        public List<GameObject> Waypoints
        {
            get => waypoints;
        }

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _levelSelectionMap = GameObject.FindObjectOfType<LevelSelectionMap>();
            
            //Facciamo ritornare il player una volta terminato il livello nella posizione di origine.
            foreach (var i in Waypoints)
            {
                if (i.GetComponent<Waypoint>() != null)
                {
                    if (i.GetComponent<Waypoint>().levelIndex == _gameManager.LevelOriginIndex)
                    {
                        currentIndex = Waypoints.FindIndex(w =>
                        {
                            return i.name.Equals(w.name);
                        });
                        _levelSelectionMap.SetStartPosition(Waypoints[currentIndex].transform.position);
                        destinationIndex = currentIndex;
                    }

                    if (i.GetComponent<Waypoint>().levelIndex == _gameManager.LevelDestinationIndex)
                    {
                        GameManager.Instance.DestinationWaypoint = i.GetComponent<Waypoint>();
                    }
                }
            }
        }
    }
}
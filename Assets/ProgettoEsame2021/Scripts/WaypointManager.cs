using System.Collections.Generic;
using UnityEngine;

namespace ProgettoEsame2021.Scripts
{
    public class WaypointManager : MonoBehaviour
    {
        //Lista che contiene i waypoints.
        public List<GameObject> waypoints = new List<GameObject>();   
        
        //Riferimenti ad altre classi.
        private GameManager _gameManager;
        private LevelSelectionMap _levelSelectionMap;
        
        //Variabili per stabilire la posizione dell'oggetto(Player) nella selezione dei livelli.
        private int currentIndex;
        private int destinationIndex;

        //Propietà
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
        
        public List<GameObject> Waypoints
        {
            get => waypoints;
        }

        //Funzione che inizilizza le variabili e viene eseguita non appena lo script è caricato.
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
                        currentIndex = Waypoints.FindIndex( match: w =>
                        {
                            return i.name.Equals(w.name);
                        }); //int
                        
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

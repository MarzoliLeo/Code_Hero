using UnityEngine;

namespace ProgettoEsame2021.Scripts
{
    public class LevelSelectionMap : MonoBehaviour
    {
        //Oggetto da muovere nel menù.
        public GameObject playerToMove;               

        //Variabile di offset per il corretto posizionamento dell' oggetto da muovere.
        private Vector3 offsetPosition = new Vector3(0.1f, 0.5f, 0);  

        //Variabile di velocità di movimento del player da un waypoint ad un altro.
        private float characterSpeed = 3;
        
        //Variabili per controllare se muovere o no l'oggetto.
        private bool movePlayer;
        private bool isLevelReached;
        
        //Riferimenti ad altre classi.
        private GameManager _gameManager;
        private Waypoint _waypoint;
        private WaypointManager _waypointManager;
        private LevelUISelection _levelUISelection;
        
    
        //Funzione per l'inizializzazione delle variabili.
        void Start()
        {
            _gameManager = GameManager.Instance;
            _waypointManager = GameObject.FindObjectOfType<WaypointManager>();
            _levelUISelection = GameObject.FindObjectOfType<LevelUISelection>();
        }

        //Funzione richiamata ad ogni Frame del gioco.
        private void Update()
        {
            MovePlayerInTheMap();
        }

        //Funzione che muove l'oggetto Player lungo un percorso(Waypoints) nella mappa del menù.
        private void MovePlayerInTheMap()
        {
            if (!movePlayer) { return; }
            transform.position = Vector3.MoveTowards(playerToMove.transform.position,
                _waypointManager.Waypoints[_waypointManager.DestinationIndex].transform.position + offsetPosition, Time.deltaTime * characterSpeed);
        }
        
        //Funzione per verificare se l'oggetto Player e i Waypoint entrano in "collisione".
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
                _levelUISelection.SetLevelText("Level " + waypointComponent.levelIndex.ToString());
                
                if (waypointComponent.levelIndex == _gameManager.LevelDestinationIndex)
                {
                    _levelUISelection.SetActiveButton(true);
                    isLevelReached = true;
                }
            }
        }

        //Funzione per verificare se l'oggetto rimane in "collisione".
        private void OnTriggerStay2D(Collider2D other)
        {
            if (!isLevelReached)
            {
                movePlayer = true;
            }
        }
    
        //Funzione per settare la posizione dell'oggetto Player alla posizione data.
        public void SetStartPosition(Vector3 startPos)
        {
            playerToMove.transform.position = startPos + offsetPosition;
        }
    }
}

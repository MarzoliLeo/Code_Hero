using UnityEngine;

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
    
        private void Start()
        {
            LevelOriginIndex = 1;
            LevelDestinationIndex = 1;
        }
    }
}

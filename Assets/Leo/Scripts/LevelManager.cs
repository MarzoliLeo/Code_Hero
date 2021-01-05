using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leo.Scripts
{
    public class LevelManager : MonoBehaviour
    {

        //Metodo per caricare un nuovo livello nel caso in cui si prema lo Start Button.
        //Il livello scelto sarà rispettivamente l'index del waypoint ad esso assocciato.
        public void LoadIndexLevel()
        {
            SceneManager.LoadScene(GameManager.Instance.DestinationWaypoint.levelIndex);
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leo.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        //Evento per far partire il timer quando il bottone di Start viene premuto.
        public delegate void OnStartClick();
        public static event  OnStartClick onStartClick;

        //Metodo per caricare un nuovo livello nel caso in cui si prema lo Start Button.
        //Il livello scelto sarà rispettivamente l'index del waypoint ad esso assocciato.
        public void LoadIndexLevel()
        {
            SceneManager.LoadScene(GameManager.Instance.DestinationWaypoint.levelIndex);
            onStartClick?.Invoke();
        }
    }
}

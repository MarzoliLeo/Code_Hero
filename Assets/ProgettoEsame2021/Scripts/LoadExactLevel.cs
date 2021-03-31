using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProgettoEsame2021.Scripts
{
    public class LoadExactLevel : MonoBehaviour
    {
        private int timeToWait = 5;
    
        //Funzione che viene chiamata appena lo script e' caricato in programma.
        void Start()
        {
            Invoke("LoadIndexLevel", timeToWait);
        }

        //Funzione per caricare l'esatto livello in base alla destinazione del Player.
        private void LoadIndexLevel()
        {
            SceneManager.LoadScene(GameManager.Instance.DestinationWaypoint.levelIndex);
        }
    }
}

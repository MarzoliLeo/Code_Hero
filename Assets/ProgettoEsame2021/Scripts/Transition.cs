using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProgettoEsame2021.Scripts
{
    public class Transition : MonoBehaviour
    {
        private  int secondsToWait = 5;

        //Funzione che viene eseguita non appena lo script è caricato.
        private void Start()
        {
            Invoke(methodName: "LoadPowerupScene", time: secondsToWait);
        }
    
        //Funzione che passa alla scena relativa ai PowerUp
        private void LoadPowerupScene()
        {
            SceneManager.LoadScene("Powerup");
        }
    }
}

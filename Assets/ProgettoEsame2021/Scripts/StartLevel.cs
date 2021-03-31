using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProgettoEsame2021.Scripts
{
    public class StartLevel : MonoBehaviour
    {
        //Invocata direttamente dal Game Engine ( Tramite il sistema di Eventi "OnClick").
        //Funzione passare alla scena di Transition al premere del bottone Start.
        public void LoadTransition()
        {
            SceneManager.LoadScene("LoadingTransition");
        }
    }
}

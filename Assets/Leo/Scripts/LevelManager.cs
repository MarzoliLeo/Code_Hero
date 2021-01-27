using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leo.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        //Metodo per caricare la transition nel caso in cui si prema lo Start Button.
        public void LoadTransition()
        {
            SceneManager.LoadScene("LoadingTransition");
        }
    }
}

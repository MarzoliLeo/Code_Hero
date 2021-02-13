
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour
{
    //Metodo per caricare la transition nel caso in cui si prema lo Start Button.
    public void LoadTransition()
    {
        SceneManager.LoadScene("LoadingTransition");
    }
}

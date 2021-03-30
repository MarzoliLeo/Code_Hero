using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Classe che gestisce i suoni.
public class SoundManager : Singleton<SoundManager>
{
    // [0] Musica del menù.
    // [1] Musica da combattimento per i livelli.
    // [2] Musica del transition.
    // [3] Musica del "The end".
    //Lista che contiene tutti i suooni.
    public List<AudioSource> _audioSource = new List<AudioSource>();

    //Funzione per collegarsi all'evento attivato al cambio di una scena.
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Funzione per scollegarsi all'evento attivato al cambio di una scena.
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    //Funzione invocata al cambio di Scena.
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopSound();
        
        //Controllo in quale scena mi trovo ed eseguo il rispettivo suono.
        if(scene.name.Equals("LevelSelectionMap"))
        {
            PlaySound(0);
        }
        else if (scene.name.Equals("LoadingTransition"))
        {
            PlaySound(2);
        }
        else if (scene.name.Equals("EndGame"))
        {
            PlaySound(3);
        }
        else if (!(scene.name.Equals("Powerup")))
        {
            PlaySound(1);
        }
    }

    //Funzione per far partire la musica di un elemento della lista.
    private void PlaySound(int index)
    {
        _audioSource[index].Play();
    }
    
    //Funzione per stoppare tutti suoni.
    public void StopSound()
    {
        foreach (AudioSource a in _audioSource)
        {
            a.Stop();
        }
    }

}

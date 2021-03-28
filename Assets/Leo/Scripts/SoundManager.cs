using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    // [0] Musica del menù.
    // [1] Musica da combattimento per i livelli.
    // [2] Musica del transition.
    // [3] Musica del "The end".
    
    public List<AudioSource> _audioSource = new List<AudioSource>();

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StopSound();
        
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
        else
        {
            //Sono nella scena di PowerUp e non voglio suoni.
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
        //Ferma tutte le clip.
        foreach (AudioSource a in _audioSource)
        {
            a.Stop();
        }
    }

}

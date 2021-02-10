using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource _audioSource;

    //metodo per far partire la musica.
    public void PlayFightSound()
    {
        _audioSource.Play();
    }
    
    //Metodo per stoppare la musica
    public void StopFightSound()
    {
        _audioSource.Stop();
    }

}

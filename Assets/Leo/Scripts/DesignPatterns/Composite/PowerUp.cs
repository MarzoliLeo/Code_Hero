using System.Collections.Generic;
using UnityEngine;

//Classe di FOGLIA

public class PowerUp : IComponent
{
    public string Name { get; set; }

    //Todo rimuovere questo construct sembra inutile...
    public PowerUp(string name)
    {
        this.Name = name;
    }
    
    //Effetto da appliccare
    public void Booster()
    {
        Debug.Log("Sono dentro il Booster del powerUp: "+ Name);
    }

    public IComponent Pick(ref List<IComponent> itemsInABox)
    {
        //todo Controllare quale tipo di powerUp e' con un booleano e effettuare le modifiche (nel GameManager) al gioco in base a quello.
        //return this;
        Debug.Log("Ho appliccato il powerUp: "+ Name);
        return this;
    }
    
}


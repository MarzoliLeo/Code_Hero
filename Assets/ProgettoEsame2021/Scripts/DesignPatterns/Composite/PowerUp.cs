using System.Collections.Generic;
using UnityEngine;

//Classe di FOGLIA

public class PowerUp : IComponent
{
    //Server per dire se un powerUp e' attivo o meno.
    public bool Active { get; set; }

    public string Name { get; set; }
    
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
        /*
        Debug.Log("Ho appliccato il powerUp: "+ Name);
        return this;
        */
        if (Name.Equals("Increase Damage"))
        {
            this.Active = true;
            Debug.Log("Ho appliccato il powerUp: "+ Name);
        }
        else if (Name.Equals("Increase Health"))
        {
            this.Active = true;
            Debug.Log("Ho appliccato il powerUp: "+ Name);
        }
        else if (Name.Equals("Slow Timer"))
        {
            this.Active = true;
            Debug.Log("Ho appliccato il powerUp: "+ Name);
        }
        return this;
    }
    
}


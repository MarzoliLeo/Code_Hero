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
        Debug.Log("Ho appliccato il powerUp: "+ Name);
    }

    public void Pick()
    {
        //return this;
        Debug.Log("Ho appliccato il powerUp: "+ Name);
    }
}


using System.Collections.Generic;
using UnityEngine;

//Classe associata alla FOGLIA

namespace ProgettoEsame2021.Scripts.DesignPatterns.Composite
{
    public class PowerUp : IComponent
    {
        //Propietà
        public bool Active { get; set; }

        public string Name { get; set; }
    
        //Costruttore
        public PowerUp(string name)
        {
            this.Name = name;
        }
    
        //Funzione ricorsiva per riconoscere quale Powerup attivare.
        public IComponent Pick(ref List<IComponent> itemsInABox)
        {
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
}


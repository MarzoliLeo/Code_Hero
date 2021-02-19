using System;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    //Creazione delle foglie
    IComponent increaseDmg = new PowerUp("Aumento Danni");
    IComponent increaseHealth = new PowerUp("Aumento Vita");
    IComponent slowTimer = new PowerUp("Rallentamento Timer");
    
    //Creazione dei components
    Box commonBox = new Box("Common",Box.BoxRarity.Common);
    Box rareBox = new Box("Rare",Box.BoxRarity.Rare); 
    Box legendaryBox = new Box( "Legendary",Box.BoxRarity.Legendary);

    private void Start()
    { 
        //commonBox = 1 powerup Random
        commonBox.AddComponent(increaseDmg);
        commonBox.AddComponent(increaseHealth);
        commonBox.AddComponent(slowTimer);
        
        //rareBox =   2 commonBox
        rareBox.AddComponent(commonBox);
        rareBox.AddComponent(commonBox);
        
        //legendaryBox = 1 rareBox + 1 commonBox
        legendaryBox.AddComponent(rareBox);
        legendaryBox.AddComponent(commonBox);
        

        commonBox.Pick();
        rareBox.Pick();
        legendaryBox.Pick();

    }
}

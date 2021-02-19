using System.Collections.Generic;
using UnityEngine;

//classe di COMPOSITE.
public class Box : IComponent
{
    //Lista delle foglie (powerUps)
    List<IComponent> components = new List<IComponent>();

    public string Name { get; set; }
    
    public BoxRarity Rarity { get; set; }
    
    public enum BoxRarity { Common, Rare, Legendary }

    //Costruttore
    public Box(string name,BoxRarity rarity)
    {
        this.Name = name;
        this.Rarity = rarity;
    }
    //Metodo che aggiunge un componente alla lista.
    public void AddComponent(IComponent component)
    {
        components.Add(component);
    }
    
    
    //Metodo per stampare il nome del componente e mostrare i booster di tutte le foglie usando un loop.
    public void Booster()
    {
        foreach (var item in components)
        {
                item.Booster();
        }
    }
    
    //Metodo per selezionare una Random dalla Composite altrimenti entra nel Composite interno.
    public void Pick()
    {
        Debug.Log("********* Sono dentro il box: " + Name + " e rarita' " + Rarity);
        if (Rarity == BoxRarity.Common)
        {
            int index = Random.Range(0,components.Count);
            components[index].Pick();
        }
        else if (Rarity == BoxRarity.Rare || Rarity == BoxRarity.Legendary)
        {
            foreach (var c in components)
            {
                c.Pick();
            }
        }

    }
}

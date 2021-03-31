using System.Collections.Generic;
using UnityEngine;

//classe associata al COMPOSITE.
namespace ProgettoEsame2021.Scripts.DesignPatterns.Composite
{
    public class Box :  IComponent
    {
        //Variabile enum. per definire la rarità di un box.
        public enum BoxRarity { Common, Rare, Legendary }
        
        //Lista delle foglie (powerUps)
        List<IComponent> components = new List<IComponent>();

        //Properties
        public bool Active { get; set; }
        public string Name { get; set; }
        public BoxRarity Rarity { get; set; }
        
        //Costruttore
        public Box(string name,BoxRarity rarity)
        {
            this.Name = name;
            this.Rarity = rarity;
        }
        
        //Funzione che aggiunge un componente alla lista.
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }
        
        //Funzione per selezionare tutti i Box ricorsivamente, ed aggiungerli ad una lista.
        public IComponent Pick(ref List<IComponent> itemsInABox)
        {
            Debug.Log("********* Sono dentro il box: " + Name + " e rarita' " + Rarity);

            if (Rarity == BoxRarity.Common)
            {
                int index = Random.Range(0,components.Count);
                itemsInABox.Add(components[index].Pick(ref itemsInABox));
            }
            else if (Rarity == BoxRarity.Rare || Rarity == BoxRarity.Legendary)
            {
                foreach (var c in components)
                {
                    c.Pick(ref itemsInABox);
                }
            }
        
            itemsInABox.Add(this);
            return this;
        }
    }
}

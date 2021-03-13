using System.Collections.Generic;

public interface IComponent
{
    
    string Name { get; set; }
    void Booster();
    IComponent Pick(ref List<IComponent> itemsInABox);
}

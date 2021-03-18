using System.Collections.Generic;

public interface IComponent
{
    bool Active { get; set; }
    string Name { get; set; }
    void Booster();
    IComponent Pick(ref List<IComponent> itemsInABox);
}

using System.Collections.Generic;

public interface IComponent
{
    bool Active { get; set; }
    string Name { get; set; }
    IComponent Pick(ref List<IComponent> itemsInABox);
}

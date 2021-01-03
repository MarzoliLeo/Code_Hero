using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// A component to add on level maps path points
public class LevelPathElement : MonoBehaviour
{
    /// should the character automatically move to the next point when reaching this one
    [Tooltip("should the character automatically move to the next point when reaching this one")]
    public bool AutomaticMovement=false;
    
    [Header("Possible Directions")]
    
    /// the path element the character should go to when going up
    [Tooltip("the path element the character should go to when going up")]
    public LevelPathElement Up;
    
    /// the path element the character should go to when going right
    [Tooltip("the path element the character should go to when going right")]
    public LevelPathElement Right;
    
    /// the path element the character should go to when going down
    [Tooltip("the path element the character should go to when going down")]
    public LevelPathElement Down;
    
    /// the path element the character should go to when going left
    [Tooltip("the path element the character should go to when going left")]
    public LevelPathElement Left;
    
    /// Determines whether this instance can go up.
    public virtual bool CanGoUp()
    {
        if (Up!=null) { return true; } else { return false; }
    }
    
    /// Determines whether this instance can go right.
    public virtual bool CanGoRight()
    {
        if (Right!=null) { return true; } else { return false; }
    }
    
    /// Determines whether this instance can go down.
    public virtual bool CanGoDown()
    {
        if (Down!=null) { return true; } else { return false; }
    }
    
    /// Determines whether this instance can go left.
    public virtual bool CanGoLeft()
    {
        if (Left!=null) { return true; } else { return false; }
    }
    // Start is called before the first frame update
    void Start()
    {
        // we turn our path element invisible (we want it on for positioning on scene view but not in our game
        GetComponent<SpriteRenderer>().enabled=false;
    }

    /// Triggered when a character enters our path element
    public virtual void OnTriggerStay2D(Collider2D collider)
    {

        LevelSelectorCharacter mapCharacter = collider.GetComponent<LevelSelectorCharacter>();
        if (mapCharacter == null)
            return;

        // we tell our character it's now colliding with a path element
        mapCharacter.CollidingWithAPathElement = true;
        mapCharacter.SetCurrentPathElement(this);
        mapCharacter._shouldMove = true;
        
        // if our path element is on automatic, we'll direct our character to its next target
        if (AutomaticMovement)
        {
            if (mapCharacter.LastVisitedPathElement!=Up && Up!=null) { mapCharacter.SetDestination(Up); }
            if (mapCharacter.LastVisitedPathElement!=Right && Right!=null) { mapCharacter.SetDestination(Right); }
            if (mapCharacter.LastVisitedPathElement!=Down && Down!=null) { mapCharacter.SetDestination(Down); }
            if (mapCharacter.LastVisitedPathElement!=Left && Left!=null) { mapCharacter.SetDestination(Left); }
        }
    }

    /// Triggered when a character exits our path element
    public virtual void OnTriggerExit2D(Collider2D collider)
    {
        LevelSelectorCharacter mapCharacter = collider.GetComponent<LevelSelectorCharacter>();
        if (mapCharacter == null)
            return;

        //TODO Disabilitare l'UI quando esci dal pathway
        
        // we tell our character it's now not colliding with any path element
        mapCharacter.CollidingWithAPathElement = false;	
        mapCharacter.SetCurrentPathElement(null);	
        mapCharacter.LastVisitedPathElement=this;
    }

    /// Triggered when a character enters our path element
    public virtual void OnTriggerEnter2D(Collider2D collider)
    {
        LevelSelectorCharacter mapCharacter = collider.GetComponent<LevelSelectorCharacter>();
        if (mapCharacter == null)
            return;
        
        mapCharacter._shouldMove = false;
        //TODO Settare il nome del livello tramite GUI. (o UI)
        // Update is called once per frame
    }
}

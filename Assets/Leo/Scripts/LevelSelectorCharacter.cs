using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// A controller for the level map's main character
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class LevelSelectorCharacter : MonoBehaviour
{
    /// the character's movement speed
    [Tooltip("the character's movement speed")]
    public float CharacterSpeed;
    
    /// the point on the map at which the character should spawn
    [Tooltip("the point on the map at which the character should spawn")]
    public LevelPathElement StartingPoint;
    
    /// true if the character colliding with a path element at this frame
    public bool CollidingWithAPathElement { get; set; }
    /// the last visited path element
    public LevelPathElement LastVisitedPathElement { get; set; }
    
    protected Rigidbody2D _rigidbody2D;
    protected BoxCollider2D _boxCollider2D;
    
    protected Vector3 _offset;
    
    protected float _horizontalMove;
    protected float _verticalMove;
    
    protected LevelPathElement _currentPathElement;
    protected LevelPathElement _destination;
    
    public bool _shouldMove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // we get our various components
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        
        // we define the offset based on the distance between our object's position and the center of the boxcollider
        _offset = _boxCollider2D.bounds.center - transform.position;
        
        // we move our character to its starting point
        transform.position = StartingPoint.transform.position-_offset;
    }

    // Update is called once per frame
    /// On update, we get the input, decide if we should move or not,
    void Update()
    {
        InputMovement();
        MoveCharacter();
    }

    /// Handles input and decides if we can move or not
    public virtual void InputMovement()
    {
        //TODO Fare un inputSystem che muova lo sprite quando sta fermo.
        // we get both direction axis
        _horizontalMove = Input.GetAxis("Horizontal");
        _verticalMove = Input.GetAxis("Vertical");
        
        if (!CollidingWithAPathElement)
        {
            return;
        }
        
        //TODO Se premi il bottone "spazio" o invio... vai al livello selezionato!
        
        // if the path element we're on right now is automated, we do nothing and exit
        if (_currentPathElement.AutomaticMovement) { return; }
        
        if (  (_currentPathElement.CanGoUp()) )
        {
            _destination=_currentPathElement.Up; _shouldMove=true;
        }
        if (  (_currentPathElement.CanGoRight()) )
        {
            _destination=_currentPathElement.Right; _shouldMove=true;
        }
        if ( (_currentPathElement.CanGoDown()) )
        {
            _destination=_currentPathElement.Down; _shouldMove=true;
        }
        if (  (_currentPathElement.CanGoLeft()) )
        {
            _destination=_currentPathElement.Left; _shouldMove=true;
        }
    }
    
    /// Moves the character to the set destination
    public virtual void MoveCharacter()
    {
        if (!_shouldMove) { return; }
        transform.position = Vector3.MoveTowards(transform.position,_destination.transform.position-_offset,Time.deltaTime*CharacterSpeed);
    }
    
    /// Sets the current path element.
    public virtual void SetCurrentPathElement(LevelPathElement pathElement)
    {
        _currentPathElement=pathElement;
    }
    
    /// Sets the destination.
    public virtual void SetDestination(LevelPathElement newDestination)
    {
        // if we haven't reached our destination yet, we do nothing and exit
        if (transform.position != _destination.transform.position-_offset) 
        { 
            return; 
        }
        // otherwise we set our new destination
        _destination=newDestination;
        _shouldMove=true;
    }
    
    /// Sets the horizontal move.
    protected virtual void SetHorizontalMove(float value)
    {
        _horizontalMove = value;
    }
    
    /// Sets the vertical move.
    protected virtual void SetVerticalMove(float value)
    {
        _verticalMove = value;
    }
}

using System;
using UnityEngine.UI;
using UnityEngine;

public interface ICharacterState
{
    ICharacterState DoState(CharacterBase character);
}

//Base Class
public abstract class CharacterBase : MonoBehaviour
{    
    //
    [SerializeField] private ICharacterState currentState;
    
    public IdleState idleState = new IdleState();
    public AttackState attackState = new AttackState();
    public DeadState deadState = new DeadState();
    
    //
    public int health;
    //Healthbar del player.
    public Slider lifeSlider;
        
    //Variabili per associare lo "spawn" del projectile.
    public  GameObject originShooting;
    public  GameObject projectile;
    public  ParticleSystem projectileEmitter;
    public ParticleSystem takingDamageEmitter;
        
    //OffSet
    protected Vector3 offset = new Vector3(0.20f,0,0);
        
    //Bool per verificare se il player è morto(Game Over).
    public bool isDead;
    //
    public bool canAttack;
        
    //Variabile per riprodurre uno shooting sound.
    public AudioClip shootingSound;

    //
    public abstract void Shoot();

    public abstract void OnTriggerEnter2D(Collider2D other);

    private void OnEnable()
    {
        currentState = idleState;
    }

    private void Update()
    {
        currentState = currentState.DoState(this);
    }
}

public class IdleState : ICharacterState
{
    public ICharacterState DoState(CharacterBase character)
    {
        Debug.Log("in idle stai fermo.!!!1h1h1h");
        if (character.canAttack)
            return character.attackState;
        else if (character.isDead)
            return character.deadState;
        else
            return character.idleState;
    }
}

public class AttackState : ICharacterState
{
    public ICharacterState DoState(CharacterBase character)
    {
        return character.idleState;
    }
    
}

public class DeadState : ICharacterState
{
    public ICharacterState DoState(CharacterBase character)
    {
        return character.idleState;
    }
}

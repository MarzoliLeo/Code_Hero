using System.Collections;
using System.Collections.Generic;
using ProgettoEsame2021.Scripts.DesignPatterns.State;
using UnityEngine;
using UnityEngine.UI;

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
    
    //Il DoState viene eseguito in continuazione, ma cambia a seconda dello stato in cui siamo.
    private void Update()
    {
        currentState = currentState.DoState(this);
    }
}

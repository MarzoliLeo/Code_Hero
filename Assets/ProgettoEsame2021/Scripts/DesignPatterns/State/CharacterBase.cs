using UnityEngine;
using UnityEngine.UI;


namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    //Classe Base da cui derivano Player, Enemy.
    public abstract class CharacterBase : MonoBehaviour
    {    
        //Variabile che definisce lo stato in cui ci troviamo.
        //[SerializeField] è un attributo per vedere il valore nel GameEngine (di Debug).
        [SerializeField] private ICharacterState currentState;
        
        //Variabili che definiscono il tipo di stato che si può assumere.
        public IdleState idleState = new IdleState();
        public AttackState attackState = new AttackState();
        public DeadState deadState = new DeadState();
    
        //Variabile che definisce la vita degli oggetti(Player,Enemy).
        public int health;
        
        //Oggetto di gioco per mostrare a video la vita.
        public Slider lifeSlider;
        
        //Oggetti di gioco per gestire le funzionalità del proiettile.
        public  GameObject originShooting;
        public  GameObject projectile;
        public  ParticleSystem projectileEmitter;
        public  ParticleSystem takingDamageEmitter;
        public  AudioClip shootingSound;
        
        //OffSet per la posizione del proiettile a video.
        protected Vector3 offset = new Vector3(0.20f,0,0);
        
        //Variabile per verificare se l'oggetto(Player,Enemy) e' "morto"(health = 0).
        public bool isDead;
        
        //Variabile per stabilire se si può attaccare.
        public bool canAttack;
        
        //Funzione da overridare per definire l'attacco.
        public abstract void Shoot();

        //Funzione da overridere per definire il contatto con il proiettile a seconda di quale sia il soggetto(Player,Enemy).
        public abstract void OnTriggerEnter2D(Collider2D other);

        //Funzione per inizializzare i valori. OnEnable viene eseguito prima della funzione Start.
        private void OnEnable()
        {
            currentState = idleState;
        }
    
        //Funzione che viene continuamente eseguita ogni frame.
        private void Update()
        {
            //Invochiamo continuamente il DoState che restituisce lo stato su cui ci troviamo. 
            currentState = currentState.DoState(this);
        }
    }
}

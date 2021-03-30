using UnityEngine;

namespace ProgettoEsame2021.Scripts
{
    public class ProjectilePlayer : MonoBehaviour
    {
        //Variabile per accedere alle proprietà fisiche di un oggetto nel gioco.
        private Rigidbody2D _rigidbody2D;
        
        //Variabili che definiscono il comportamento del proiettile.
        private int projectileSpeed = 10;
        private int damage = 1;
        
        //Proprietà.
        public int Damage
        {
            get => damage;
            set => damage = value;
        }
        
        //Funzione che viene chiamata appena lo script e' caricato in programma.
        //Funzione per l'inizializzazione delle variabili.
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = Vector2.right * projectileSpeed;
        }
    }
}

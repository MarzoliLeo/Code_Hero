using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    public class Player : CharacterBase
    {
        //Siccome non era possibile accedere al Prefab dell'enemy proiettile a RunTime per modificarne il damage.
        //Variabile specifica del Player poichè utile ai fini del PowerUp.
        private int _damage = 1;

        //Propietà
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        
        //Funzione per gestire l'attacco del player.
        public  override void Shoot()
        {
            if (canAttack)
            {
                //Funzione per lo spawn visivo del proiettile (Definita in MonoBehaviour).
                Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
                AudioSource.PlayClipAtPoint(shootingSound,originShooting.transform.position,1);
                //Particle System giallo.
                projectileEmitter.Play();
            }
        }
        
        //Funzione per far gestire il contatto col proiettile, del nemico col player.
        public override void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            //Particle System cuori.
            takingDamageEmitter.Play();
            //Imposto la vita del player a -1.
            var damage = other.GetComponent<ProjectileEnemy>().Damage;
            health -= damage;
            lifeSlider.value -= damage;
            if (health <= 0)
            {
                isDead = true;
            }
        }
    }
}

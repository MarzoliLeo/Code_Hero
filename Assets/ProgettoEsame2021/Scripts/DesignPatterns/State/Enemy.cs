using UnityEngine;

namespace ProgettoEsame2021.Scripts.DesignPatterns.State
{
    public class Enemy : CharacterBase
    {
        //Funzione per gestire l'attacco del nemico.
        public override void Shoot()
        {
            if (canAttack)
            {
                //Funzione per lo spawn visivo del proiettile (Definita in MonoBehaviour).
                Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
                AudioSource.PlayClipAtPoint(shootingSound, originShooting.transform.position, 1);
                //Particle System giallo
                projectileEmitter.Play();
            }
        }

        //Funzione per far gestire il contatto col proiettile, del player col nemico.
        public override void OnTriggerEnter2D(Collider2D other)
        {
            Destroy(other.gameObject);
            //Particle System cuori
            takingDamageEmitter.Play();
            //Imposto la vita dell'enemy a -1.
            var damage = other.GetComponent<ProjectilePlayer>().Damage;
            health -= damage;
            lifeSlider.value -= damage;
            if (health <= 0)
            {
                isDead = true;

            }
        }
    }
}


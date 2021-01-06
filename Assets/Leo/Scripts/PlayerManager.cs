using System;
using UnityEngine;

namespace Leo.Scripts
{
    public class PlayerManager : MonoBehaviour
    {
        //Variabili per associare lo "spawn" del projectile.
        public  GameObject originShooting;
        public  GameObject projectile;
        

        //OffSet
        private Vector3 offset = new Vector3(0.20f,0,0);

        private void Start()
        {
            
        }

        //Funzione per gestire lo shooting del player.
        public  void ShotToEnemy(int damage)
        {
            //Funzione per lo spawn visivo del player (Definita in MonoBehaviour)
            Instantiate(projectile, originShooting.transform.position + offset, Quaternion.identity);
        }
    }
}

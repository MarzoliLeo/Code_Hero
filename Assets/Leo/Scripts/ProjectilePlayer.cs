using System;
using UnityEditor;
using UnityEngine;

namespace Leo.Scripts
{
    public class ProjectilePlayer : MonoBehaviour
    {
        //Accesso alla componente di RigidBody che ne da le proprietà fisiche.
        private Rigidbody2D _rigidbody2D;
        
        //Velocità del projectile nel sparare
        private int projectileSpeed = 10;
        
        
        // Start is called before the first frame update
        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = Vector2.right * projectileSpeed;
        }
    }
}

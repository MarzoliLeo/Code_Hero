using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    //Accesso alla componente di RigidBody che ne da le proprietà fisiche.
    private Rigidbody2D _rigidbody2D;
        
    //Velocità del projectile nel sparare
    private int projectileSpeed = 9;
    private int damage = 1;

    public int Damage
    {
        get => damage;
        set => damage = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = Vector2.left * projectileSpeed;
    }
}

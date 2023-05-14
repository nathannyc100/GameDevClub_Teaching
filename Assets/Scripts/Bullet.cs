using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 shootDirection;
    private float speed = 10;
    private Rigidbody2D rigidbody;

    public void Setup(Vector3 shootDirection)
    {
        this.shootDirection = shootDirection; 
        this.rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = shootDirection * speed;
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Wall"){
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy"){ 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.health -= 10;

            Destroy(this.gameObject);
        }
    }

}

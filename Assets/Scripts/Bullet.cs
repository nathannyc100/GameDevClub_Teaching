using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 shootDirection;
    private float speed = 10;
    private Rigidbody2D rigidbodyComponent;

    public void Setup(Vector2 shootDirection)
    {
        this.shootDirection = shootDirection; 
        this.rigidbodyComponent = GetComponent<Rigidbody2D>();
        rigidbodyComponent.velocity = shootDirection * speed;
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Wall"){
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Enemy"){ 
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.DecreaseHealth(10);

            Destroy(this.gameObject);
        }
    }

}

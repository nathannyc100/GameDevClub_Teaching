using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody2D enemyRigidbody;
    
    private float collisionTime = 0;
    private float collisionInterval = 1f;
    public int health;
    private Vector2 movementVector;
    [SerializeField]
    private float speed = 1f;

    private void Awake(){
        health = 100;

        characterController = FindObjectOfType<CharacterController>();
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update(){ 
        if (health <= 0){ 
            Destroy(gameObject);
        }
    }

    private void FixedUpdate(){
        movementVector = (characterController.position - enemyRigidbody.position).normalized;

        enemyRigidbody.velocity = movementVector * speed;
    }

    private void OnCollisionStay2D(Collision2D collision2D){
        Debug.Log("collide");

        if (collision2D.gameObject.tag != "Player"){
            return;
        }

        if (Time.time - collisionTime > collisionInterval){
            characterController.DecreaseHealth(10);

            collisionTime = Time.time;
        }
        
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterController characterController;
    private Rigidbody2D enemyRigidbody;
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    
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
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }



    private void FixedUpdate(){
        movementVector = (characterController.position - enemyRigidbody.position).normalized;

        enemyRigidbody.velocity = movementVector * speed;
    }

    private void OnCollisionStay2D(Collision2D collision2D){
        if (collision2D.gameObject.tag != "Player"){
            return;
        }

        if (Time.time - collisionTime > collisionInterval){
            characterController.DecreaseHealth(10);

            collisionTime = Time.time;
        }
        
    }

    public void DecreaseHealth(int amount){
        this.health -= amount;
        spriteRenderer.color = Color.red;
        Invoke("ChangeColor", 0.2f);

        if (health <= 0)
        {
            DeleteEnemy();
        }
    }

    private void ChangeColor(){
        spriteRenderer.color = Color.white;
    }

    private void DeleteEnemy(){
        int index = gameManager.enemies.IndexOf(this.gameObject);
        gameManager.enemies.RemoveAt(index);

        gameManager.score += 10;
        Debug.Log(gameManager.score);
        Destroy(this.gameObject);
    }

    
}

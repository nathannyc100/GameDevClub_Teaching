using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class CharacterController : MonoBehaviour
{
    private PlayerInput playerInput;
    public Sprite dino;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;
    private InputController inputController;
    private Rigidbody2D rigidbodyComponent;
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private Camera mainCamera;
    private GameManager gameManager;

    public Vector2 position;
    public int health;
    private float bulletTimer;
    private float bulletInterval = 0.1f;
    private float autoBulletInterval = 0.2f;
    private bool fireToggle = false;
    private bool aimToggle = false;

    private float horizontalMovement;
    private float verticalMovement;

    private Vector3 movementVector;

    public int speed;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        inputController = gameObject.GetComponent<InputController>();
        rigidbodyComponent = gameObject.GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();  

        inputController.OnFired += When_OnFired;
        inputController.FireToggle += When_FireToggle;
        inputController.AimToggle += When_AimToggle;

        health = 100;
        bulletTimer = 0;
    }

    // Update is called once per frame
    void Update(){
        if (rigidbodyComponent.velocity.x < 0){
            spriteRenderer.flipX = true;
        } else if (rigidbodyComponent.velocity.x > 0) {
            spriteRenderer.flipX = false;
        }

        if (fireToggle && Time.time - bulletTimer > autoBulletInterval){
            FireBullet();
        }
    }

    

    void FixedUpdate(){
        rigidbodyComponent.velocity = inputController.velocity * speed;

        position = rigidbodyComponent.position;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Wall"){
        }
    }

    private void When_OnFired(object sender, EventArgs e){
        if (Time.time - bulletTimer < bulletInterval){
            return;
        }

        if (fireToggle){
            return;
        }

        FireBullet();
    
    }

    public void DecreaseHealth(int amount){
        health -= amount;

        Debug.Log(health);
    }

    private void When_FireToggle(object sender, EventArgs e){
        fireToggle = !fireToggle;
    }

    private void When_AimToggle(object sender, EventArgs e){
        aimToggle = !aimToggle;
    }

    private void FireBullet(){
        Bullet bulletInstance = Instantiate(bullet, rigidbodyComponent.position, Quaternion.identity);

        Vector2 dinoPosition = rigidbodyComponent.position;
        Vector2 shootDirection;

        if (aimToggle){
            shootDirection = new Vector2(1000, 1000);

            foreach (GameObject enemy in gameManager.enemies){
                Vector2 enemyPosition = enemy.transform.position;
                Vector2 nextShootDirection = (enemyPosition - dinoPosition);

                if (nextShootDirection.magnitude < shootDirection.magnitude){
                    shootDirection = nextShootDirection;
                }
            }
        } else {
            Vector2 mousePosition = Input.mousePosition;
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);
            shootDirection = (mousePosition - dinoPosition);
        }
        
        shootDirection = shootDirection.normalized;

        bulletInstance.Setup(shootDirection);

        bulletTimer = Time.time;
    }

}

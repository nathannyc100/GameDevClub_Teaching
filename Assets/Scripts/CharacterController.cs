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
    private Rigidbody2D rigidbody;
    public Rigidbody2D bullet;
    [SerializeField]
    private Camera mainCamera;

    private float horizontalMovement;
    private float verticalMovement;

    private Vector3 movementVector;

    public int speed;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerInput = gameObject.GetComponent<PlayerInput>();
        inputController = gameObject.GetComponent<InputController>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        inputController.OnFired += When_OnFired;
    }

    // Update is called once per frame
    void Update(){
        // horizontalMovement = Input.GetAxis("Horizontal");
        // verticalMovement = Input.GetAxis("Vertical");

        // animator.SetFloat("XAxis", Mathf.Abs(horizontalMovement));
        // animator.SetFloat("YAxis", verticalMovement);

        // movementVector = new Vector3(horizontalMovement, verticalMovement, 0);

        //transform.Translate(movementVector * Time.deltaTime * 10);

        

        if (rigidbody.velocity.x < 0){
            spriteRenderer.flipX = true;
        } else if (rigidbody.velocity.x > 0) {
            spriteRenderer.flipX = false;
        }
    }

    

    void FixedUpdate(){
        rigidbody.velocity = inputController.velocity * speed;
    }

    //Invoke c# events
    // private void OnEnable(){
    //     playerInput.onActionTriggered += When_onActionTriggered;
    // }

    // private void When_onActionTriggered(InputAction.CallbackContext ctx){
    //     Debug.Log(ctx);

    //     if (ctx.action.name == "Jump"){
    //         if (ctx.phase == InputActionPhase.Performed){
    //             Debug.Log("performed");
    //         }
    //     }
    // }

    //Send / Broadcast message
    // private void OnJump(InputValue value){
    //     float jumpValue = value.Get<float>();
    //     Debug.Log("Jumped");
    // }

    //Invoke Unity Events
    public void OnJump(InputAction.CallbackContext ctx){
        Debug.Log(ctx);
    
        if (ctx.phase == InputActionPhase.Performed){
            Debug.Log("Jump performed");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Wall"){
            Debug.Log("Bumped into wall");
        }
    }

    private void When_OnFired(object sender, EventArgs e){
        Rigidbody2D bulletRigidbody = Instantiate(bullet, rigidbody.position, Quaternion.identity);

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 dinoPosition = rigidbody.position;
        Vector2 shootDirection = (mousePosition - dinoPosition);
        shootDirection = shootDirection.normalized;

        bulletRigidbody.GetComponent<Bullet>().Setup(shootDirection);
    }



}

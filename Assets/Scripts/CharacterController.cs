using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    private PlayerInput playerInput;
    public Sprite dino;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;

    private float horizontalMovement;
    private float verticalMovement;

    private Vector3 movementVector;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerInput = gameObject.GetComponent<PlayerInput>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        animator.SetFloat("XAxis", Mathf.Abs(horizontalMovement));
        animator.SetFloat("YAxis", verticalMovement);

        movementVector = new Vector3(horizontalMovement, verticalMovement, 0);

        transform.Translate(movementVector * Time.deltaTime * 10);

        if (movementVector.x < 0){
            spriteRenderer.flipX = true;
        } else if (movementVector.x > 0) {
            spriteRenderer.flipX = false;
        }
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
    // public void OnJump(InputAction.CallbackContext ctx){
    //     Debug.Log(ctx);
    //
    //     if (ctx.phase == InputActionPhase.Performed){
    //         Debug.Log("Jump performed");
    //     }
    // }



}

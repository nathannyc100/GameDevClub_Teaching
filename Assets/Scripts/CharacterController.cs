using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Sprite dino;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Animator animator;

    private float horizontalMovement;
    private float verticalMovement;

    private Vector3 movementVector;

    private void Awake(){
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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
}

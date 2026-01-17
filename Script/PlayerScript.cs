using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerController : MonoBehaviour
{
    // SERIALIZED FIELDS
    [SerializeField] private float moveSpeed = 1f;

    // PRIVATE FIELDS
    private PlayerControls playerControls;
    private Vector2 movement;
    
  
    private Rigidbody2D rb; 
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender; 

    
    private Vector2 mouseScreenPosition; 


    private void Awake() {
        playerControls = new PlayerControls();
        
        
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void OnDisable() {
        playerControls.Disable();
    }

    private void Update() {
        PlayerInput();
        
        
        mouseScreenPosition = playerControls.Movement.mousePosition.ReadValue<Vector2>(); 
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection(); 
        Move();
    }

    private void PlayerInput() {
        
        movement = playerControls.Movement.move.ReadValue<Vector2>();

       
        myAnimator.SetFloat("move x", movement.x);
        myAnimator.SetFloat("move y", movement.y);
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() {
        
        Vector3 mousePos = mouseScreenPosition; 
        
       
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        
        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRender.flipX = true;
        } else {
            mySpriteRender.flipX = false; 
        }
    }
}
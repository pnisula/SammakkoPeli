using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupuMovement : MonoBehaviour
{
    public GameObject character;
    public float moveSpeed = 3.25f;
    public float jumpSpeed;
    private Rigidbody2D rb;

    private Vector2 playerInput;
    private bool shouldJump;
    private bool canJump;


    private void Start()
    {
        rb = character.GetComponent<Rigidbody2D>();
    }

    // get input values each frame
    private void Update()
    {
        // using "GetAxis" allows for many different control schemes to work here
        // go to Edit -> Project Settings -> Input to see and change them
        playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (canJump && Input.GetButtonDown("Jump"))
        {
            canJump = false;
            shouldJump = true;
            Debug.Log("Jumping started");
        }
    }

    // apply physics movement based on input values
    private void FixedUpdate()
    {
        // move
        if (playerInput != Vector2.zero)
        {
            rb.AddForce(playerInput * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
        }

        // jump
        if (shouldJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            shouldJump = false;
            Debug.Log("Jump activated");
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Floor");
        // allow jumping again
        canJump = true;
        character.transform.tag = "onFloor";
        
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        character.transform.tag = "Jumping";
    }    
}

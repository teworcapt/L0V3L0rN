using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed;

    //RigidBody (Physics)
    public Rigidbody2D rigidBody;

    // Where Player moves
    private Vector2 movementInput;

    // Access Animator to play animations
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //gets component/information on the player and stores it on the variables
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

    }

    // Fixed frames unlike Update [Physics Calculation]
    private void FixedUpdate()
    {
        //makes our player move
        rigidBody.velocity = movementInput * moveSpeed;
    }

    //To get the Input System Clicks
    private void OnMove(InputValue inputValue)
    {
        // Converts WASD controls to Vector 2 values (X,Y)
        movementInput = inputValue.Get<Vector2>();
    }

}

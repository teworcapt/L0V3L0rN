using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerManager : MonoBehaviour
{
    [Header("Components")]
    public Animator anim;
    public Rigidbody2D rigidBody;
    private Vector2 movementInput;
    public int moveSpeed;
    public string startPoint;

    [Header("Components")]
    private static bool playerExist;
    public bool canMove;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        if (!playerExist) //for not destroying player per scene
        {
            playerExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }


        canMove = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove)
        {
            rigidBody.velocity = Vector2.zero;
            anim.enabled = false;
            return;
        } 
        else
        {
            anim.enabled = true; //lets player animations move after dialogue
        }

        //player movement
        rigidBody.velocity = movementInput * moveSpeed;
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    private void OnMove(InputValue inputValue)
    {
        // Converts WASD controls to Vector 2 values (X,Y)
        movementInput = inputValue.Get<Vector2>();
    }

}

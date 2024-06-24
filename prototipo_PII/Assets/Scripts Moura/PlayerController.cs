using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class PlayerController : MonoBehaviour
{
    public DialogueManager dialogueManager;
    float horizontalInput;
    public float moveSpeed = 5f;
    bool isFacingRight = false;

    Rigidbody2D rb;
    //public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");//Recebe o input.
        FlipSprite();

    }

    private void FixedUpdate()
    {
        if (!dialogueManager.dialogueBoxesAreOpen)
        {
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y); // Transform input into movement.
        }
        else
        {
            rb.velocity = Vector2.zero; // Stop player movement while dialogue is active.
        }
        //animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        //animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput > 0f || !isFacingRight && horizontalInput < 0f)
        {
            isFacingRight = !isFacingRight;
            //Vector3 ls = transform.localScale;
            //ls.x *= -1f;
            //transform.localScale = ls;
            transform.Rotate(0f, 180f, 0f);

        }
    }
}
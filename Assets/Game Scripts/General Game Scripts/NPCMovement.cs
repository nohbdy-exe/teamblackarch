using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    public float moveSpeed = 0.8f;
    public float changeDirectionInterval = 7f;
    private Vector2 movementDirection;
    private Rigidbody2D rb;
    private Animator animator;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;  // Prevent rotation
        InvokeRepeating(nameof(ChangeDirection), 0f, changeDirectionInterval);
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movementDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }

    void ChangeDirection()
    {
        int directionChoice = Random.Range(0, 3); // down left or up

        switch (directionChoice)
        {
            case 0:
                movementDirection = Vector2.left; // Move left
                animator.SetFloat("MoveX", -1);
                animator.SetFloat("MoveY", 0);
            break;

            case 1:
                movementDirection = Vector2.down; // Move down
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", -1);
            break;

            case 2:
                movementDirection = Vector2.up; // Move up
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 1);
            break;

            animator.SetFloat("Speed", movementDirection.magnitude); // sets speed
        }
    }
}

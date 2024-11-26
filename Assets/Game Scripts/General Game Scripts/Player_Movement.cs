using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed = 2f;
    [SerializeField] private int TimeDivider = 3;
    [SerializeField] private Animator animator;
    [SerializeField] private Dialog dialog;
    public AudioSource audioSource;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector2(3,3);
        audioSource = GetComponent<AudioSource>();
        
        
    }

    // Update is called once per frame
    public void PlayerUpdate()
    {
        PlayerMovement();
        UpdateAnimation();
    }

    

    //Character Movement
    void PlayerMovement()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        
        if (Mathf.Abs(horizontalInput) > 0.1f) {
            rb.velocity = new Vector2(horizontalInput * PlayerSpeed, 0);
        }
        else if (Mathf.Abs(verticalInput) > 0.1f){
            rb.velocity = new Vector2(0, verticalInput * PlayerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            CallDialog();
        }
        
        // footstep sound
        HandleFootstepSound();

    }

    void UpdateAnimation() {
        if (rb.velocity != Vector2.zero) {
            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical",rb.velocity.y);

            GetComponent<SpriteRenderer>().flipX = rb.velocity.x > 0;
        }
        else {
            animator.SetBool("Walking", false);
        }
    }

    void HandleFootstepSound()
    {
        if (rb.velocity.magnitude > 0 && !audioSource.isPlaying)
        {
            audioSource.Play(); // Play sound when moving
        }
        else if (rb.velocity.magnitude == 0 && audioSource.isPlaying)
        {
            // Check if the audio is near the end of the clip (e.g., within 0.1 seconds)
            if (audioSource.time >= audioSource.clip.length - 0.1f)
            {
                audioSource.Stop(); // Stop sound when it finishes playing
            }
        }
    }

    void CallDialog() {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }
}

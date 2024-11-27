using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] protected float PlayerSpeed = 2f;
    [SerializeField] protected int TimeDivider = 3;
    Rigidbody2D rb;
    Vector2 checkMovement;
    [SerializeField] Animator animator;
    [SerializeField] Dialog playerDialog;
    public AudioSource audioSource;
    private bool isDialogActive = false;
    
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
        if(!isDialogActive){ // allows movement only when dialog state isn't active
        PlayerMovement();
        UpdateAnimation();
        }
    }

    //Character Movement
    void PlayerMovement()
    {
        
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f) {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*PlayerSpeed,0);
        }
        else {
            rb.velocity = new Vector2(0,Input.GetAxisRaw("Vertical")*PlayerSpeed);
        }

        if (Input.GetKeyDown(KeyCode.E) && !isDialogActive) {           
            TriggerDialog(playerDialog);       
        }
        
        // footstep sound
        if (rb.velocity.magnitude > 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

    }

    void UpdateAnimation() {
    
        if (rb.velocity != Vector2.zero) {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
                this.GetComponent<SpriteRenderer>().flipX = true;
            } else {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.SetBool("Walking", true);
            animator.SetFloat("Horizontal", rb.velocity.x);
            animator.SetFloat("Vertical",rb.velocity.y);
        }
        else {
            animator.SetBool("Walking", false);
        }
    }   
    
    
    public void TriggerDialog(Dialog dialog) {
        
        if (dialog == null || dialog.dialogLines == null || dialog.dialogLines.Count == 0)
        {
            Debug.LogError("Dialog is null or improperly configured!");
            return;
        }
        DialogManager.Instance.StartDialog(dialog);
    }

    void EndDialog()
    {
        isDialogActive = false;
    }
}

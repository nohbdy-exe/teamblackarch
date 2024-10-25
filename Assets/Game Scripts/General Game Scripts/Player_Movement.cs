using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    protected float PlayerSpeed = 2f;
    protected int TimeDivider = 3;
    Rigidbody2D rb;
    Vector2 checkMovement;
    public Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector2(3,3);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        UpdateAnimation();
    }

    //Character Movement
    void PlayerMovement()
    {
        
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) >0.1f) {
            rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*PlayerSpeed,0);
        }
        else {
            rb.velocity = new Vector2(0,Input.GetAxisRaw("Vertical")*PlayerSpeed);
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
}

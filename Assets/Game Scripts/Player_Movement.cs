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
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
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
}

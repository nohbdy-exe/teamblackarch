using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float PlayerSpeed = 2f;
    public int TimeDivider = 3;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    //Character Movement
    public void PlayerMovement()
    {
        //Get Character Position
        Vector3 pos = transform.position;
        
        //WASD movement
        if (Input.GetKey("w"))
        {
            pos.y += PlayerSpeed * Time.deltaTime / TimeDivider;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= PlayerSpeed * Time.deltaTime / TimeDivider;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= PlayerSpeed * Time.deltaTime / TimeDivider;
        }
        if (Input.GetKey("d"))
        {
            pos.x += PlayerSpeed * Time.deltaTime / TimeDivider;
        }

        //Arrowkey movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += PlayerSpeed * Time.deltaTime/TimeDivider;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= PlayerSpeed * Time.deltaTime/TimeDivider;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= PlayerSpeed * Time.deltaTime/TimeDivider;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += PlayerSpeed * Time.deltaTime/TimeDivider;
        }

        transform.position = pos;
    }
}

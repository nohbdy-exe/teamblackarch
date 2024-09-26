using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{
    public Transform Player;
    public Vector3 offset;
    [SerializeField]
    float xOffset;
    [SerializeField]
    float yOffset;
    public Vector3 offsetDefault;
    [SerializeField]
    protected float movementSpeed = 3f;
    [SerializeField]
    float zoomFactor = 1.0f;

    [SerializeField]
    float zoomSpeed = 2.0f;

    private float originalSize = 0f;

    private Camera thisCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Setting OffsetDefault
        offsetDefault.x = 0; offsetDefault.y = 0; offsetDefault.z = -5;
        offset = offsetDefault;

        //Camera Setup
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        //Creating camera zoom effects
        float targetSize = originalSize * zoomFactor;
        if (targetSize != thisCamera.orthographicSize)
        {
            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize,
            targetSize, Time.deltaTime * zoomSpeed);
        }
        playerTracker();
    }

     void playerTracker()
    {
        //Setting Inputs
        //slowly animates camera movement for smoother transition
        if (Input.GetKey("w"))
        {   SetZoom(1f);
            yOffset = .05f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            SetZoom(1f);
            yOffset = .05f;
        }
        if (Input.GetKey("s"))
        {
            SetZoom(1f);
            yOffset = -.05f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            SetZoom(1f);
            yOffset = -.05f;
        }
        if (Input.GetKey("a"))
        {
            SetZoom(1f);
            xOffset = -.05f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            SetZoom(1f);
            xOffset = -.05f;
        }
        if (Input.GetKey("d"))
        {
            SetZoom(1f);
            xOffset = .05f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            SetZoom(1f);
            xOffset = .05f;
        }
        if (!Input.anyKey)
        {
            SetZoom(0.9f);
            xOffset = 0;
            yOffset = 0;
        }
        
        float xTarget = Player.position.x + xOffset;
        float yTarget = Player.position.y + yOffset;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * movementSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * movementSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);
        transform.position = new Vector3(Player.position.x + xOffset,
       Player.position.y + yOffset, transform.position.z);
    }
    void SetZoom(float zoomFactor)
    {
        this.zoomFactor = zoomFactor;
    }
}

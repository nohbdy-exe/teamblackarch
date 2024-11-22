using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    public Transform exteriorPosition; // Set the position inside the house where the player will appear
    public Camera mainCamera; // Reference to the main camera
    public Vector3 cameraOffset; // Offset to focus the camera on the interior

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Move player to the interior position
            other.transform.position = exteriorPosition.position;

             // Adjust camera to focus on the interior
            mainCamera.transform.position = exteriorPosition.position + cameraOffset;
        }
    }
}
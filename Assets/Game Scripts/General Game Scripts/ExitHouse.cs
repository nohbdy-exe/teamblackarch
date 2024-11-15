using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHouse : MonoBehaviour
{
    public GameObject player;
    public Transform exteriorPosition;
    public Camera mainCamera;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the collider
        if (other.gameObject == player)
        
        {
            // Teleport the player outside
            player.transform.position = exteriorPosition.position;
        }
    }
}

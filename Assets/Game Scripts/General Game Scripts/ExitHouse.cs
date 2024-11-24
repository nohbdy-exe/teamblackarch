using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHouse : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject houseExteriorEntrance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        
            sceneController.EnterExitHouse(houseExteriorEntrance.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCave : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private GameObject caveExteriorEntrance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))

            sceneController.EnterExitCave(caveExteriorEntrance.transform.position);
    }
}

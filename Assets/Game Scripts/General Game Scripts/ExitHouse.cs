using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitHouse : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private AudioSource doorOpen;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpen.Play();
            sceneController.PreviousScene();
        }
    }
}
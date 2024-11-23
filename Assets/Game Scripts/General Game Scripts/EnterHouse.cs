using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHouse : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private Player_Movement player;
    PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            doorOpen.Play();
            sceneController.NextScene();
            //playerData.playerLoc = this.transform.position;
        }
    }
}
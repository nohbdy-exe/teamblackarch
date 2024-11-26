using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterCave : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    //Detect collisions between the GameObjects with Colliders attached
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Player")
        {
            DataPersistenceManager.Instance.SaveGame();
            sceneController.EnterCustomScene("BattleScene");
        }
    }
}

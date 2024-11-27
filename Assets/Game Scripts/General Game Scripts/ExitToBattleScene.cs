using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToBattleScene : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            playerData.battleActive = true;
            sceneController.EnterCustomScene("BattleScene");
        } 
    }
}

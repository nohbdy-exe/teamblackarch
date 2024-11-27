using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterBattleScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private SceneController sceneController;
    [SerializeField] private PlayerData playerData;
    //Detect collisions between the GameObjects with Colliders attached
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Player")
        {
            playerData.battleActive = true;
            sceneController.EnterCustomScene("BattleScene");
        }
        
    }
    
}

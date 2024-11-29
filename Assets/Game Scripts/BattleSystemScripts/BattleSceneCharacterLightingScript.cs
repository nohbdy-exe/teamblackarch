using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BattleSceneCharacterLightingScript : MonoBehaviour
{
    [Header("Player Information:")]
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpotlight;
    
    [Header("Boss Information:")]
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform BossSpotlight;
    [SerializeField] private Transform BossRedlight;

    private float playerX;
    private float currentPlayerX;
    private float amountPlayerMoved;
    private float bossX;
    private float currentBossX;
    private float amountBossMoved;

    void Start()
    {
        playerX = player.transform.position.x;
        currentPlayerX = player.transform.position.x;
        bossX = boss.transform.position.x;
        currentBossX = boss.transform.position.x;

    }
    private void UpdateLightingLocation()
    {
        //Check amount moved
        
        if (playerX != currentPlayerX)
        {
            amountPlayerMoved = (currentPlayerX - playerX);
            playerX = currentPlayerX;
            Vector2 newPlayerLightPosition = new Vector2(playerSpotlight.position.x + amountPlayerMoved, playerSpotlight.position.y);
            playerSpotlight.position = newPlayerLightPosition;
        }
        if (bossX != currentBossX)
        {
            amountBossMoved = (currentBossX - bossX);
            bossX = currentBossX;
            Vector2 newBossLightPosition = new Vector2(BossSpotlight.position.x + amountBossMoved, BossSpotlight.position.y);
            BossSpotlight.position = newBossLightPosition;
            BossRedlight.position = newBossLightPosition;
         }
       
    }
    void Update()
    {
        currentPlayerX = player.transform.position.x;
        currentBossX = boss.transform.position.x;
        UpdateLightingLocation();
    }
}

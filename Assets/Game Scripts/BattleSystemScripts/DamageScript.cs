using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    bool playerTurn;
    bool bossTurn;
    int bossRndSelect;
    private float bossOutputDamage;
    private float bossPhysicalAttackDamage = 5;
    private float rndMultiplier;
    private float bossMagicAttackDamage = 3;
    private float bossHealFactor = 4;
    private float bossSelfHeal;
    private float playerOutputDamage;
    private float playerPhysicalAttackDamage = 5;
    private float playerMagicAttackDamage = 3;
    private float playerHealFactor = 4;
    private float playerSelfHeal;
    private float playerManaChargeFactor = 5;
    private float playerManaCharge;
    private float mpCost;
    [SerializeField] TheFallenData bossScript;
    [SerializeField] PlayerData playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerTurn = true;
        bossTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Get Battle Inputs:
    public void RunBattleInputSystem()
    {
        if (playerTurn && !bossTurn)
        {
            
        }
        if (bossTurn && !playerTurn)
        {
            BossInput();
        }
        if (!playerTurn && !bossTurn)
        {
            //Do something for whichever death occured (ie player restart last checkpoint / player wins add XP)
        }
    }
    public void PlayerInput()
    {
        //Populate this once UI is running
        playerTurn = false;
        bossTurn = true;
    }
    public void BossInput()
    {
        bossRndSelect = bossScript.rndSelection();
        if (bossRndSelect == 1)
        {
            BossPhysicalAttack();
        }
        else if (bossRndSelect == 2)
        {
            BossMagicAttack();
        }
        else if (bossRndSelect == 3)
        {
            BossHeal();
        }
        bossTurn = false;
        playerTurn = true;

    }
    #endregion
    #region Boss Turn Options
    private void BossPhysicalAttack()
    {
        rndMultiplier = Random.Range(3, 12);
        bossOutputDamage = bossPhysicalAttackDamage * rndMultiplier;
        playerScript.UpdatePlayerHPfromDamage(bossOutputDamage);
    }
    private void BossMagicAttack()
    {
        rndMultiplier = Random.Range(3, 25);
        bossOutputDamage = bossMagicAttackDamage * rndMultiplier;
        playerScript.UpdatePlayerHPfromDamage(bossOutputDamage);
    }
    private void BossHeal()
    {
        rndMultiplier = Random.Range(5, 22);
        bossSelfHeal = bossHealFactor * rndMultiplier;
        bossScript.UpdateBossHPfromHeal(bossSelfHeal);
    }
    #endregion
    #region Player Turn Options:
    private void PlayerPhysicalAttack()
    {
        mpCost = 18;
        if (playerScript.playerMana >= mpCost)
        {
            rndMultiplier = Random.Range(6, 14);
            playerOutputDamage = playerPhysicalAttackDamage * rndMultiplier;
            bossScript.UpdateBossHPfromDamage(playerOutputDamage);
            playerScript.UpdatePlayerMPfromUse(mpCost);
        }
        
    }
    private void PlayerMagicAttack()
    {
        mpCost = 20;
        if (playerScript.playerMana >= mpCost)
        {
            rndMultiplier = Random.Range(5, 28);
            playerOutputDamage = playerMagicAttackDamage * rndMultiplier;
            bossScript.UpdateBossHPfromDamage(playerOutputDamage);
            playerScript.UpdatePlayerMPfromUse(mpCost);
        }
        
    }
    private void PlayerHeal()
    {
        mpCost = 16;
        if (playerScript.playerMana >= mpCost)
        {
            rndMultiplier = Random.Range(5, 20);
            playerSelfHeal = playerHealFactor * rndMultiplier;
            playerScript.UpdatePlayerHPfromHeal(playerSelfHeal);
            playerScript.UpdatePlayerMPfromUse(mpCost);
        }
        
    }
    private void RechargeMana()
    {
        rndMultiplier = Random.Range(4, 16);
        playerManaCharge = playerManaChargeFactor * rndMultiplier;
        playerScript.UpdatePlayerMPfromRecharge(playerManaCharge);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageScript : MonoBehaviour
{
    bool playerTurn;
    bool bossTurn;
    int bossRndSelect;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator bossAnimator;
    private float bossOutputDamage;
    private float bossPhysicalAttackDamage = 3;
    private float rndMultiplier;
    private float bossMagicAttackDamage = 2;
    private float bossHealFactor = 4;
    private float bossSelfHeal;
    private float playerOutputDamage;
    private float playerPhysicalAttackDamage = 6;
    private float playerMagicAttackDamage = 4;
    private float playerHealFactor = 4;
    private float playerSelfHeal;
    private float playerManaChargeFactor = 5;
    private float playerManaCharge;
    private float mpCost;
    [SerializeField] private GameObject PlayerInputUI;
    [SerializeField] TheFallenData bossScript;
    [SerializeField] PlayerData playerScript;
    [SerializeField] TMP_Text playerHPText;
    [SerializeField] TMP_Text playerMPText;
    [SerializeField] TMP_Text bossHPText;
    [SerializeField] TMP_Text playerNameText;
    [SerializeField] private GameObject winUI;
    [SerializeField] private GameObject lossUI;
    // Start is called before the first frame update
    void Start()
    {

        playerTurn = true;
        bossTurn = false;
        Debug.Log(playerScript.playerName);
        playerNameText.text = playerScript.playerName;
        playerHPText.text = "HP:" + playerScript.playerHealth + "/" + playerScript.playerMaxHealth;
        playerMPText.text = "MP:" + playerScript.playerMana + "/" + playerScript.playerMaxMana;
        bossHPText.text = "HP: " + bossScript.bossHP + "/" + bossScript.bossMaxHP;
        RunBattleInputSystem();
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
            PlayerInputUI.SetActive(true);
            
        }
        if (bossTurn && !playerTurn)
        {
            PlayerInputUI.SetActive(false);
            BossInput();
        }
        if (!playerTurn && !bossTurn)
        {
            PlayerInputUI.SetActive(false);
            if (bossTurn)
            {

            }
        }
    }
    
    public IEnumerator WaitTime(float time)
    {

        yield return new WaitForSeconds(time);
        RunBattleInputSystem();
        /* if (bossTurn)
        {
            bossTurn = false;
            playerTurn = true;
            
        }
        else
        {
            playerTurn = false;
            bossTurn = true;
            
        }
        */
    }
    public IEnumerator WinTime(float time)
    {

        yield return new WaitForSeconds(time);
        winUI.SetActive(true);
        lossUI.SetActive(false);
       
    }
    public IEnumerator LoseTime(float time)
    {

        yield return new WaitForSeconds(time);
        winUI.SetActive(false);
        lossUI.SetActive(true);

    }
    private void PopulatePlayerStats()
    {
        playerHPText.text = "HP: " + playerScript.playerHealth + "/" + playerScript.playerMaxHealth;
        playerMPText.text = "MP: " + playerScript.playerMana + "/" + playerScript.playerMaxMana;
        bossHPText.text = "HP: " + bossScript.bossHP + "/" + bossScript.bossMaxHP;
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
        PopulatePlayerStats();
        SetPlayerTurn();
        CheckDeaths();


    }
    #endregion
    #region Boss Turn Options
    private void BossPhysicalAttack()
    {
        rndMultiplier = Random.Range(3, 12);
        bossOutputDamage = bossPhysicalAttackDamage * rndMultiplier;
        playerScript.UpdatePlayerHPfromDamage(bossOutputDamage);
        Debug.Log("Boss uses physical attack");
        //Show what boss is doing
        bossAnimator.SetTrigger("TheFallenAttack");

    }
    private void BossMagicAttack()
    {
        rndMultiplier = Random.Range(3, 22);
        bossOutputDamage = bossMagicAttackDamage * rndMultiplier;
        playerScript.UpdatePlayerHPfromDamage(bossOutputDamage);
        Debug.Log("Boss uses magical attack");
        //Show what boss is doing
        bossAnimator.SetTrigger("TheFallenAttack");
    }
    private void BossHeal()
    {
        rndMultiplier = Random.Range(5, 22);
        bossSelfHeal = bossHealFactor * rndMultiplier;
        bossScript.UpdateBossHPfromHeal(bossSelfHeal);
        bossScript.bossHealSFX();
        Debug.Log("Boss uses heal");
        //Show what boss is doing
        //PLay animations here
    }
    #endregion
    #region Player Turn Options:
    public void PlayerPhysicalAttack()
    {
        mpCost = 18;
        if (playerScript.playerMana >= mpCost)
        {
            rndMultiplier = Random.Range(6, 14);
            playerOutputDamage = playerPhysicalAttackDamage * rndMultiplier;
            bossScript.UpdateBossHPfromDamage(playerOutputDamage);
            playerScript.UpdatePlayerMPfromUse(mpCost);
            playerAnimator.SetTrigger("PlayerAttack");
            PopulatePlayerStats();
            SetBossTurn();

        }
        
    }
    public void PlayerMagicAttack()
    {
        mpCost = 20;
        if (playerScript.playerMana >= mpCost)
        {
            rndMultiplier = Random.Range(5, 28);
            playerOutputDamage = playerMagicAttackDamage * rndMultiplier;
            bossScript.UpdateBossHPfromDamage(playerOutputDamage);
            playerScript.UpdatePlayerMPfromUse(mpCost);
            playerAnimator.SetTrigger("PlayerAttack");

            PopulatePlayerStats();
            SetBossTurn();
        }
        
    }
    public void PlayerHeal()
    {
        mpCost = 16;
        if (playerScript.playerMana >= mpCost)
        {
            rndMultiplier = Random.Range(5, 20);
            playerSelfHeal = playerHealFactor * rndMultiplier;
            playerScript.UpdatePlayerHPfromHeal(playerSelfHeal);
            playerScript.UpdatePlayerMPfromUse(mpCost);
            playerScript.playerHealSFX();
            PopulatePlayerStats();
            SetBossTurn();
            
        }
        
    }
    public void RechargeMana()
    {
        rndMultiplier = Random.Range(4, 16);
        playerManaCharge = playerManaChargeFactor * rndMultiplier;
        playerScript.UpdatePlayerMPfromRecharge(playerManaCharge);
        //PLay animations here
        PopulatePlayerStats();
        SetBossTurn();
    }
    private void SetBossTurn()
    {
        if (playerScript.playerDeath == false && bossScript.bossDeath == false)
        {
            playerTurn = false;
            bossTurn = true;
            PlayerInputUI.SetActive(false);
            StartCoroutine(WaitTime(5));
        }
        else
        {
            CheckDeaths();
        }
    }
    private void SetPlayerTurn()
    {
        if (playerScript.playerDeath == false && bossScript.bossDeath == false)
        {
            bossTurn = false;
            playerTurn = true;
            PlayerInputUI.SetActive(true);
            StartCoroutine(WaitTime(5));
        }
        else
        {
            CheckDeaths();
        }
    }
    private void CheckDeaths()
    {
        if (playerScript.playerDeath == true && bossScript.bossDeath == false)
        {
            playerTurn = false;
            bossTurn = false;
            PlayerInputUI.SetActive(false);
            playerAnimator.SetTrigger("PlayerDeath");
            StartCoroutine(LoseTime(3));
            //You lose UI
        }
        else if (playerScript.playerDeath == false && bossScript.bossDeath == true)
        {
            playerTurn = false;
            bossTurn = false;
            PlayerInputUI.SetActive(false);
            bossAnimator.SetTrigger("TheFallenDeath");
            StartCoroutine(WinTime(3));
            //You win UI
            // Go to credits
        }
       

    }
    #endregion
}

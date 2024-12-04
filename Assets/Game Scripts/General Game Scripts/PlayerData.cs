using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    public Vector2 playerLoc;
    public int playerLevel;
    public int sceneNum;
    public float playerHealth;
    public float playerMana;
    public float playerExp;
    public float playerExpMax;
    public string playerName;
    public int playerSP;
    public int playerMaxLvl=5;
    public float playerMaxMana = 100;
    public float playerMaxHealth = 100;
    public bool battleActive;
    public bool playerDeath;
    [SerializeField] private AudioClip playerAttackAudio;
    [SerializeField] private AudioClip playerHealAudio;
    [SerializeField] private AudioClip playerDeathAudio;
    [SerializeField] private AudioSource playerAudioSource;
    #region Loading System:
    public void LoadData(GameData data)
    {
        Debug.Log("PlayerData Load Data was called");
        this.playerLoc = data.playerLocation;
        this.playerLevel = data.playerLvl;
        this.sceneNum = data.sceneNumber;
        this.playerHealth = data.playerHP;
        this.playerMana = data.playerMP;
        this.playerExp = data.playerXP;
        this.playerExpMax = data.playerXPMax;
        this.playerMaxHealth = data.playerMaxHP;
        this.playerMaxMana = data.playerMaxMP;
        this.playerName = data.playerNick;
    }
    public void SaveData(ref GameData data)
    {
        SetDataToSave();
        data.playerLvl = this.playerLevel;
        data.sceneNumber = this.sceneNum;
        data.playerLocation = this.playerLoc;
        data.playerHP = this.playerHealth;
        data.playerMP = this.playerMana;
        data.playerXP = this.playerExp;
        data.playerXPMax = this.playerExpMax;
        data.playerMaxHP = this.playerMaxHealth;
        data.playerMaxMP = this.playerMaxMana;
        data.playerNick = this.playerName;
        //Debug.Log("Attempting to save scene number to " + playerLevel.ToString() + ", Player location to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString());
        //Debug.Log("Data saved scene number to " + data.playerLvl.ToString() + ", Player location to x: " + data.playerLocation.x.ToString() + ", y: " + data.playerLocation.y.ToString() + ", Player level to: " + data.playerLvl.ToString());
    }
    
    public void SetPlayerName(string playername)
    {
        this.playerName = playername;
    }

    private void SetDataToSave()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        playerLoc = this.transform.position;
        
        //Debug.Log("Attempting to save scene number saved to " + sceneNum.ToString() + ", Player location saving to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString() + ", Player level saving to: " + playerLevel.ToString());

    }
    public void SetDataToLoad()
    {


        if (SceneManager.GetActiveScene().name != "BattleScene")
        {
            if (SceneManager.GetActiveScene().buildIndex != sceneNum)
            {
                SceneManager.LoadSceneAsync(sceneNum);

            }
            this.transform.position = playerLoc;
        }
        else
        {
            if (!battleActive)
            {
                battleActive = true;
            }
        }
       

        Debug.Log("Loaded data was set.");
    }
    #endregion
    public void CheckLevelingSystem()
    {
        //Check to see if the player has leveled up
        if (playerExp >= playerExpMax)
        {
            if (playerLevel != playerMaxLvl)
            {
                playerExp = playerExp - playerExpMax;
                playerSP++;
                playerLevel++;
                playerExpMax += 50;
            }
            else
            {
                playerExp = playerExpMax;
            }
        }
    }
    public void CheckHPStatus()
    {
        //Check to see if player's HP is higher than 0
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            playerDeath = true;
        }
        //Check to see if player's HP is higher than allowed
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
        
    }
    public void CheckMPStatus()
    {
        //Check to see if player's MP is higher than 0
        if (playerMana <= 0)
        {
            playerMana = 0;
        }
        //Check to see if player's MP is higher than allowed
        if (playerMana > playerMaxMana)
        {
            playerMana = playerMaxMana;
        }
    }
    public void playerAttackSFX()
    {
        playerAudioSource.clip = playerAttackAudio;
        playerAudioSource.volume = 100;
        playerAudioSource.Play();
    }
    public void playerDeathSFX()
    {
        playerAudioSource.clip = playerDeathAudio;
        playerAudioSource.Play();
    }
    public void playerHealSFX()
    {
        playerAudioSource.clip= playerHealAudio;
        playerAudioSource.Play();
    }
    void Start()
    { 
        this.SetDataToLoad();
    }

    void Update()
    {
        CheckHPStatus();
        CheckLevelingSystem();
        CheckMPStatus();
    }
    #region Battle Data Updater:
    public void UpdatePlayerHPfromDamage(float incomingDamage)
    {
        if (incomingDamage != 0)
        {
            //Check to see if boss can sustain hit
            if (playerHealth > incomingDamage)
            {
                playerHealth -= incomingDamage;
                playerDeath = false;
            }
            if (playerHealth <= incomingDamage)
            {
                playerHealth = 0;
                playerDeath = true;
            }
        }
    }
    public void UpdatePlayerHPfromHeal(float incomingHeal)
    {
        if (playerHealth != playerMaxHealth)
        {
            if (incomingHeal != 0)
            {
                if (incomingHeal + playerHealth > playerMaxHealth)
                {
                    playerHealth = playerMaxHealth;
                }
                if (incomingHeal + playerHealth <= playerMaxHealth)
                {
                    playerHealth += incomingHeal;
                }
            }
        }
        else
        {
            Debug.Log("Boss is at max health");
        }
    }
    public void UpdatePlayerMPfromUse(float costMP)
    {
        playerMana -= costMP;
    }
    public void UpdatePlayerMPfromRecharge(float recharge)
    {
        if (playerMana + recharge <= playerMaxMana)
        {
            playerMana += recharge;
        }
        else
        {
            playerMana = playerMaxMana;
        }
    }
    
    #endregion
}

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
    public int playerSP;
    public int playerMaxLvl=5;
    public float playerMaxMana = 100;
    public float playerMaxHealth = 100;
    public bool battleActive = false;
    /*
    [Header("Player HUD Info:")]
    [SerializeField] public GameObject PlayerLevelHUD;
    [SerializeField] public GameObject PlayerSkillPointsHUD;
    [SerializeField] public GameObject PlayerHealthHUD;
    [SerializeField] public GameObject PlayerManaHUD;
    [SerializeField] public GameObject PlayerExpHUD;
    [SerializeField] public TextMeshProUGUI playerHealthText;
    */

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
        //Debug.Log("Attempting to save scene number to " + playerLevel.ToString() + ", Player location to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString());
        //Debug.Log("Data saved scene number to " + data.playerLvl.ToString() + ", Player location to x: " + data.playerLocation.x.ToString() + ", y: " + data.playerLocation.y.ToString() + ", Player level to: " + data.playerLvl.ToString());
    }
    
    private void SetDataToSave()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        playerLoc = this.transform.position;
        
        //Debug.Log("Attempting to save scene number saved to " + sceneNum.ToString() + ", Player location saving to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString() + ", Player level saving to: " + playerLevel.ToString());

    }
    public void SetDataToLoad()
    {
        if (battleActive)
        {
            if (SceneManager.GetActiveScene().name != "BattleScene")
            {
                SceneManager.LoadScene("BattleScene");
            }
        }

        if (!battleActive)
        {
            if (SceneManager.GetActiveScene().buildIndex != sceneNum)
            {
                SceneManager.LoadSceneAsync(sceneNum);
                this.transform.position = playerLoc;
            }
        }

        

        Debug.Log("Loaded data was set.");
    }
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
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            battleActive = true;
        }
        this.SetDataToLoad();
    }
    void Update()
    {
        CheckHPStatus();
        CheckLevelingSystem();
        CheckMPStatus();
    }
}

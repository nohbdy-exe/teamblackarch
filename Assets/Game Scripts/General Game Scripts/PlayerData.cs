using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    public Vector2 playerLoc;
    public int playerLevel;
    public int sceneNum;
    public float playerHealth;
    public float playerMana;
    public float playerExp;
    public float playerExpReq;
    public int playerSP;
    public int playerMaxLvl=5;

    public void LoadData(GameData data)
    {
        Debug.Log("PlayerData Load Data was called");
        this.playerLoc = data.playerLocation;
        this.playerLevel = data.playerLvl;
        this.sceneNum = data.sceneNumber;
        this.playerHealth = data.playerHP;
        this.playerMana = data.playerMP;
        this.playerExp = data.playerXP;
        this.playerExpReq = data.playerXPReq;
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
        data.playerXPReq = this.playerExpReq;
        //Debug.Log("Attempting to save scene number to " + playerLevel.ToString() + ", Player location to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString());
        //Debug.Log("Data saved scene number to " + data.playerLvl.ToString() + ", Player location to x: " + data.playerLocation.x.ToString() + ", y: " + data.playerLocation.y.ToString() + ", Player level to: " + data.playerLvl.ToString());
    }
    
    private void SetDataToSave()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        playerLoc = this.transform.position;
        playerLevel = 3;
        //Debug.Log("Attempting to save scene number saved to " + sceneNum.ToString() + ", Player location saving to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString() + ", Player level saving to: " + playerLevel.ToString());

    }
    public void SetDataToLoad()
    {
        this.transform.position = playerLoc;
        Debug.Log("Loaded data was set.");
    }
    public void CheckLevelingSystem()
    {
        //Check to see if the player has leveled up
        if (playerExp >= playerExpReq)
        {
            if (playerLevel != playerMaxLvl)
            {
                playerExp = playerExp - playerExpReq;
                playerSP++;
                playerLevel++;
                playerExpReq += 50;
            }
            else
            {
                playerExp = playerExpReq;
            }
        }
    }
    void Start()
    {
        this.SetDataToLoad();
    }
}

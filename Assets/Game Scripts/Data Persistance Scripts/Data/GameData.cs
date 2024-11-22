using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData 
{
    public Vector2 playerLocation;
    public int playerLvl;
    public int sceneNumber;
    public float playerHP;
    public float playerMP;
    public float playerXP;
    public float playerXPMax;
    public int playerSkillPoints;
    public float playerMaxHP;
    public float playerMaxMP;
    
    
    //This houses the values the game will start with when there is no data to load
    public GameData()
    {
        playerLocation = new Vector2 (0f,0f);
        playerLvl = 1;
        sceneNumber = 1;
        playerHP = 100;
        playerMP = 100;
        playerXP = 0;
        playerXPMax = 50;
        playerSkillPoints = 0;
        playerMaxHP = 100;
        playerMaxMP = 100;
    }
    

}

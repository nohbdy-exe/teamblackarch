using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour, IDataPersistance
{
    private Vector2 playerLoc;
    private int playerLevel;
    private int sceneNum;
    Rigidbody2D rb;

    public void loadData(GameData data)
    {
        this.playerLoc = data.playerLocation;
        this.playerLevel = data.playerLvl;
        this.sceneNum = data.sceneNumber;
    }
    public void saveData(ref GameData data)
    {
        data.playerLocation = this.playerLoc;
        data.playerLvl = this.playerLevel;
        data.sceneNumber = this.sceneNum;
    }

    public void Update()
    {
        sceneNum = SceneManager.loadedSceneCount;
        playerLoc = rb.position;
    }
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}

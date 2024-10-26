using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour, IDataPersistence
{
    private Vector3 playerLoc;
    private int playerLevel;
    private int sceneNum;

    public void LoadData(GameData data)
    {
        playerLoc = data.playerLocation;
        playerLevel = data.playerLvl;
        sceneNum = data.sceneNumber;
        SetDataToLoad();
    }
    public void SaveData(ref GameData data)
    {
        SetDataToSave();
        data.playerLvl = playerLevel;
        data.sceneNumber = sceneNum;
        data.playerLocation = playerLoc;
    }
    private void SetDataToSave()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        playerLoc = this.transform.position;
        playerLevel = 3;
        Debug.Log("Scene number saved to " + sceneNum.ToString() + ", Player location saved to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString() + ", z: " + playerLoc.z.ToString() + ", Player level saved to: " + playerLevel.ToString());

    }
    private void SetDataToLoad()
    {
        this.transform.position = this.playerLoc;
        SceneManager.LoadScene(sceneNum);
    }
}

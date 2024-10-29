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
        data.playerLvl = this.playerLevel;
        data.sceneNumber = this.sceneNum;
        data.playerLocation = this.playerLoc;
        Debug.Log("Attempting to save scene number to " + playerLevel.ToString() + ", Player location to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString() + ", z: " + playerLoc.z.ToString() + ", Player level to: " + playerLevel.ToString());
        Debug.Log("Data saved scene number to " + data.playerLvl.ToString() + ", Player location to x: " + data.playerLocation.x.ToString() + ", y: " + data.playerLocation.y.ToString() + ", z: " + data.playerLocation.z.ToString() + ", Player level to: " + data.playerLvl.ToString());
    }
    private void SetDataToSave()
    {
        sceneNum = SceneManager.GetActiveScene().buildIndex;
        playerLoc = this.transform.position;
        playerLevel = 3;
        Debug.Log("Attempting to save scene number saved to " + sceneNum.ToString() + ", Player location saving to x: " + playerLoc.x.ToString() + ", y: " + playerLoc.y.ToString() + ", z: " + playerLoc.z.ToString() + ", Player level saving to: " + playerLevel.ToString());

    }
    private void SetDataToLoad()
    {
        this.transform.position = this.playerLoc;
        SceneManager.LoadScene(sceneNum);
    }
}

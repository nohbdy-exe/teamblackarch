using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScript : MonoBehaviour
{
    public bool SavePresent1 = false;
    public bool SavePresent2 = false;
    public bool SavePresent3 = false;

    //Returns player to the Main Menu
    public void ReturnToMainFromLoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Checks for load in save slot 1 if not loads new game
    public void LoadGame1()
    {
        if (SavePresent1 == true)
        {
            DataPersistanceManager.Instance.filename = "Game1Data.game";
            DataPersistanceManager.Instance.LoadGame();
        }
        else
        {
            DataPersistanceManager.Instance.filename = "Game1Data.game";
            DataPersistanceManager.Instance.NewGame();
        }
    }

    public void LoadGame2()
    {
        if (SavePresent2 == true)
        {
            DataPersistanceManager.Instance.filename = "Game2Data.game";
            DataPersistanceManager.Instance.LoadGame();
        }
        else
        {
            DataPersistanceManager.Instance.filename = "Game2Data.game";
            DataPersistanceManager.Instance.NewGame();
        }
    }

    public void LoadGame3()
    {
        if (SavePresent3 == true)
        {
            DataPersistanceManager.Instance.filename = "Game3Data.game";
            DataPersistanceManager.Instance.LoadGame();
        }
        else
        {
            DataPersistanceManager.Instance.filename = "Game3Data.game";
            DataPersistanceManager.Instance.NewGame();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ReturnToMainFromLoadMenu();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;


public class DataPersistanceManager : MonoBehaviour
{

    private GameData gameData;
    private List<IDataPersistance> dataPersistanceObjects;

    public static DataPersistanceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one data persistance manager in the scene.");
        }
        Instance = this;
    }
    private void Start()
    {
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
    }

    public void NewGame()
    {
        int sceneNum = gameData.sceneNumber;
        this.gameData = new GameData();
        SceneManager.LoadScene(gameData.sceneNumber);
    }
    
    public void LoadGame()
    {
        //If no data can be loaded intitialize new game
        if (this.gameData == null) 
        {
            Debug.Log("No game data was found. Initializing data to defaults");
            NewGame();
        
        }

        //push data to all other scripts that need it
        foreach(IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.loadData(gameData);
        }
    }


    public void SaveGame()
    {
        //pass data to other scripts so they can update
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            dataPersistanceObj.saveData(ref gameData);
        }
    }

    private void OnApplicationQuit()
    {
        
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }
}

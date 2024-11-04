using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Rendering;


public class DataPersistenceManager : MonoBehaviour
{
    public string filename;
    private GameData gameData = new GameData();
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    private string namedFile;

    public static DataPersistenceManager Instance { get; private set; }

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

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        Debug.Log("Initializing Game");
        Debug.Log(Application.persistentDataPath);
    }

    public void NewGame()
    {
        this.gameData = new GameData();
        SceneManager.LoadScene(gameData.sceneNumber);

    }

    public void LoadGame()
    {
        //Load any saved data from a file GameData FileDataHandler.Load()
        this.gameData = dataHandler.Load();

        //If no data can be loaded intitialize new game
        if (this.gameData == null)
        {
            Debug.Log("No game data was found. Initializing data to defaults");
            NewGame();

        }

        //push data to all other scripts that need it
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.LoadData(gameData);
        }
    }


    public void SaveGame()
    {
        //pass data to other scripts so they can update
        foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(ref gameData);
        }

        // Save data to a file using the data handler
        dataHandler.Save(gameData);
    }

    /*private void OnApplicationQuit()
    {
        
    }
    */

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
            .OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistanceObjects);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.Rendering;
using UnityEditor.SceneManagement;



public class DataPersistenceManager : MonoBehaviour
{
    private string filename = "SaveData.game";
    private GameData gameData = new GameData();
    private List<IDataPersistence> dataPersistenceObjects;
    private FileDataHandler dataHandler;
    [SerializeField] private GameObject gameObject;
    //Removes built in errors when loading game
    [Header("Dev Features")]
    [SerializeField] private bool InitializeDataIfNull = false;


    public static DataPersistenceManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one data persistance manager in the scene. Destroying the newest one.");
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, filename);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneUnloaded -= OnSceneUnloaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();
        Debug.Log("Initializing Game");
        Debug.Log(Application.persistentDataPath);
    }

    public void OnSceneUnloaded(Scene scene)
    {
        SaveGame();
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

        //Start from a new game if data is null for Developmental Use (Removes errors for starting game without having a save in place)
        if (this.gameData == null && InitializeDataIfNull)
        {
            NewGame();
        }

        //If no data can be loaded don't continue
        if (this.gameData == null)
        {
            Debug.Log("No game data was found. A New Game must be started before any saved data can be loaded.");
            return;

        }
        
            Debug.Log("Game data was found.");

            //push data to all other scripts that need it
            foreach (IDataPersistence dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
                Debug.Log("Loaded: " + dataPersistenceObj.ToString());
            }

            
            Debug.Log("Player location loaded: " + gameData.playerLocation);

            
        
    }
   


    public void SaveGame()
    {
        if (this.gameData == null)
        {
            Debug.LogWarning("No game data was found. A New Game must be started before any data can be saved.");
            return;
        }

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
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public bool HasGameData()
    {
        return gameData != null;
    }
}

using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public LoadMenuScript loadScript; //= new LoadMenuScript();
    public GameMenuLauncher gameMenuLauncher; //= new GameMenuLauncher();
    public void ResumeGame()
    {
        //Resumes Game
        gameMenuLauncher.Resume();
        gameMenuLauncher.isPaused = false;
    }
    public void SaveGame()
    {
        // Uses DataPersistanceManager to save game
        Debug.Log("Saving Game Information");
        DataPersistenceManager.Instance.SaveGame();
        gameMenuLauncher.GameWasSaved();
    }
    public void OpenOptions()
    {
        Debug.Log("Opening Options Menu");
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        //Returns to Main Menu
        Debug.Log("Quiting Game");
        SceneManager.LoadScene(0);
    }
    

}

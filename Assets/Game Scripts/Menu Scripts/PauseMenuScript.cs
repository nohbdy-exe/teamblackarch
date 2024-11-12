using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{

    public GameMenuLauncher gameMenuLauncher; //= new GameMenuLauncher();
    [SerializeField] private Button SaveGameButton;
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
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
        
    }
    

}

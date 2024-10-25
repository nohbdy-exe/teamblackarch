using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public GameMenuLauncher gameMenuLauncher;
    public void ResumeGame()
    {
        //Resumes Game
        gameMenuLauncher.Resume();
        gameMenuLauncher.isPaused = false;
    }
    public void SaveGame()
    {
        // Uses DataPersistanceManager to save game
        DataPersistanceManager.Instance.SaveGame();
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

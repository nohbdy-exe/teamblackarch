using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
    
    public GameMenuLauncher gameMenuLauncher; //= new GameMenuLauncher();
    public Color previousColor;
    [SerializeField] private TextMeshProUGUI SaveGameButtonText;
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
        Debug.Log("Data was saved.");
        previousColor = SaveGameButton.image.color;
        SaveGameButton.image.color = Color.green;
        SaveGameButtonText.text = ("Saved");
        IEnumerator waiter() { yield return new WaitForSecondsRealtime(1); SaveGameButton.image.color = previousColor; SaveGameButtonText.text = ("Game Saved"); SaveGameButtonText.text = ("Save"); }
        StartCoroutine(waiter());
        
    }

    

    public void OpenOptions()
    {
        Debug.Log("Opening Options Menu");
        gameMenuLauncher.OpenOptions();
    }
    public void QuitGame()
    {
        //Returns to Main Menu
        Debug.Log("Quiting Game");
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
        
    }
    

}

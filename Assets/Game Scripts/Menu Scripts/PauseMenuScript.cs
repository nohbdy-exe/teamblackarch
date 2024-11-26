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
    private bool saveAllowed = false;
    public GameObject saveFailed;
    [SerializeField] private TextMeshProUGUI SaveGameButtonText;
    [Header("Pause Menu Buttons:")]
    [SerializeField] private Button SaveGameButton;
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button QuitButton;
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
        if (saveAllowed)
        {
            DisablePauseMenuButtons();
            DataPersistenceManager.Instance.SaveGame();
            Debug.Log("Data was saved.");
            previousColor = SaveGameButton.image.color;
            SaveGameButton.image.color = Color.green;
            SaveGameButtonText.text = ("Saved");
            IEnumerator waiter() { yield return new WaitForSecondsRealtime(1); SaveGameButton.image.color = previousColor; SaveGameButtonText.text = ("Save"); EnablePauseMenuButtons(); }
            StartCoroutine(waiter());

        }
        else
        {
            DisablePauseMenuButtons();
            saveFailed.SetActive(true);
            IEnumerator saveFailWaiter() { yield return new WaitForSecondsRealtime(2); saveFailed.SetActive(false); EnablePauseMenuButtons(); }
            StartCoroutine (saveFailWaiter());
        }
    }

    private void DisablePauseMenuButtons()
    {
        SaveGameButton.interactable = false;
        ResumeButton.interactable = false;
        OptionsButton.interactable = false;
        QuitButton.interactable = false;
    }

    private void EnablePauseMenuButtons()
    {
        SaveGameButton.interactable = true;
        ResumeButton.interactable = true;
        OptionsButton.interactable = true;
        QuitButton.interactable = true;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button continueGameBtn;
    [SerializeField] private Button quitBtn;

    private void Start()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            continueGameBtn.interactable = false;
        }
    }
    public void ContinueGame()
    {
        DisableMenuButtons();
        SceneManager.LoadSceneAsync("Level_1");
    }
    
    public void NewGame()
    {
        DisableMenuButtons();
        DataPersistenceManager.Instance.NewGame();

        SceneManager.LoadSceneAsync("Level_1");
    }

    public void QuitGame()
    {
        DisableMenuButtons();
        Application.Quit();
    }

  
    private void DisableMenuButtons()
    {
        newGameBtn.interactable = false;
        quitBtn.interactable = false;
        continueGameBtn.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

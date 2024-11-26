using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    [Header("Menu Buttons")]
    [SerializeField] private Button newGameBtn;
    [SerializeField] private Button continueGameBtn;
    [SerializeField] private Button quitBtn;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private Button confirmYesGameBtn;
    [SerializeField] private Button confirmNoGameBtn;
    [SerializeField] private TextMeshProUGUI confirmText;

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

    public void OnConfirmYesClick()
    {
        DataPersistenceManager.Instance.NewGame();
        SceneManager.LoadSceneAsync("Level_1");
    }

    public void OnConfirmNoClick()
    {
        confirmPanel.gameObject.SetActive(false);
        EnableMenuButtons();
    }
    
    public void NewGame()
    {
        DisableMenuButtons();
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            DataPersistenceManager.Instance.NewGame();

            SceneManager.LoadSceneAsync("Level_1");
        }
        else
        {    
            confirmPanel.gameObject.SetActive(true);
        }
       
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

    private void EnableMenuButtons()
    {
        newGameBtn.interactable = true;
        quitBtn.interactable = true;
        continueGameBtn.interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

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
    [SerializeField] private AudioSource audioConfirmSound;
    [SerializeField] private SceneController sceneController;

    private void Start()
    {
        if (!DataPersistenceManager.Instance.HasGameData())
        {
            continueGameBtn.interactable = false;
        }
        sceneController.gameObject.SetActive(true);

    }
    public void ContinueGame()
    {
        DisableMenuButtons();
        sceneController.EnterCustomScene("Level_1");
    }

    public void OnConfirmYesClick()
    {
        DataPersistenceManager.Instance.NewGame();
        sceneController.EnterCustomScene("CharacterCreation");
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

            sceneController.EnterCustomScene("CharacterCreation");
        }
        else
        {    
            confirmPanel.gameObject.SetActive(true);
            audioConfirmSound.Play();
        }
       
    }

    public void QuitGame()
    {
        DisableMenuButtons();
        sceneController.ExitGame();
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

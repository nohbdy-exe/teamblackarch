using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCreationScript : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Text placeHolder;
    [SerializeField] private TMP_Text continueTxtUpdate;
    [SerializeField] private Button continueBtn;
    [SerializeField] private Button confirmNoBtn;
    [SerializeField] private Button confirmYesBtn;
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private SceneController sceneController;
    GameData gameData;

    public void ContinuePrompt()
    {
        confirmPanel.SetActive(true);
        continueTxtUpdate.text = "Start game with " + nameInput.text + "?";
        DisableMenuButtons();
    }

    public void ContinueGame()
    {
        DisableMenuButtons();
        sceneController.EnterCustomScene("Level_1");
    }

    public void OnConfirmYesClick()
    {
        string playerChar = nameInput.text;
        DataPersistenceManager.Instance.NewGameNamed(playerChar);
        sceneController.EnterCustomScene("Level_1");
    }

    public void OnConfirmNoClick()
    {
        confirmPanel.gameObject.SetActive(false);
        EnableMenuButtons();
    }

    private void DisableMenuButtons()
    {
        nameInput.interactable = false;
    }

    private void EnableMenuButtons()
    {
        nameInput.interactable = true;
    }

    private void Start()
    {
        sceneController.gameObject.SetActive(true);

        if (nameInput != null)
        {
            nameInput.onValueChanged.AddListener(OnInputChanged);
        }
    }

    private void OnInputChanged(string val)
    {
        if (!string.IsNullOrEmpty(val))
        {
            placeHolder.gameObject.SetActive(false);
        }
        else
        {
            placeHolder.gameObject.SetActive(true);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuLauncher : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerHUD;
    public Player_Movement playerChar;
    public GameObject optionMenuUI;
    public SceneController sceneController;
    public float mySfxVolume=1;
    public float myMusicVolume=1;
    bool playerHudToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        sceneController.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
        
    }

    void PauseCheck()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (isPaused == false)
            {
                isPaused = true;
                Pause();

            }
            else if (isPaused == true && optionMenuUI.activeSelf == false)
            {
                isPaused = false;
                Resume();
            }
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (isPaused == false)
            {
                isPaused = true;
                PauseStatus();
            }
            else if (isPaused == true && optionMenuUI.activeSelf == false)
            {
                isPaused = false;
                PauseStatus();
            }
        }
    }
    public void Pause()
    {

        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
        playerChar.PausePlayerMovement();

    }

    public void PauseStatus()
    {
        playerHudToggle = !playerHudToggle;
        playerHUD.SetActive(playerHudToggle);
    }

    public void Resume()
    {

        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
        playerHUD.SetActive(false);
        playerChar.PausePlayerMovement();

    }
   
    public void OpenOptions()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.SetActive(true);
    }
   
    
}

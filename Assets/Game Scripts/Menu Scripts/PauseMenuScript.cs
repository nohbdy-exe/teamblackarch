using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameMenuLauncher gameMenuLauncher;
    public void ResumeGame()
    {
        //Resumes Game
        gameMenuLauncher.Resume();
        gameMenuLauncher.isPaused = false;
    }
    public void QuitGame()
    {
        //Exits Game
        
        Application.Quit();

    }

}

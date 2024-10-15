using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public GameMenuLauncher gameMenuLauncher;
    public void ResumeGame()
    {
        gameMenuLauncher.Resume();
        gameMenuLauncher.isPaused = false;
    }

}

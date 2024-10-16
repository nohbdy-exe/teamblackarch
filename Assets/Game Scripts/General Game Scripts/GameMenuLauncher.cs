using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuLauncher : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        
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
            else if (isPaused == true)
            {
                isPaused = false;
                Resume();
            }
        }
    }
    public void Pause()
    {
        
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);

    }
    public void Resume()
    {
        
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);

    }
}

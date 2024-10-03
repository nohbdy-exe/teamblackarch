using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuLauncher : MonoBehaviour
{
    public bool isPaused=false;
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                Time.timeScale = 0;
                
            }
            else if (isPaused)
            {
                isPaused = false;
                Time.timeScale = 1;
                
            }
        }
    }
}

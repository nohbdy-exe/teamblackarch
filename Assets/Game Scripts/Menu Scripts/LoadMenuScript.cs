using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScript : MonoBehaviour
{
    
    //Returns player to the Main Menu
    public void ReturnToMainFromLoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Checks for load in save slot 1 if not loads new game
    public void Load()
    {
        DataPersistenceManager.Instance.LoadGame();
    }
    public void StartNewGame()
    {
        DataPersistenceManager.Instance.NewGame();
    }

 

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ReturnToMainFromLoadMenu();
        }
    }
    
}

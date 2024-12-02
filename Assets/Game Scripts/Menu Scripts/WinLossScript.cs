using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossScript : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        SceneManager.LoadSceneAsync("TitleScreen");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ReturnToLastSave()
    {
        SceneManager.LoadSceneAsync("Level_1");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    [SerializeField] Animator sceneTransition;
    public static SceneController instance;
    [SerializeField] Player_Movement player;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void NextScene() {
        StartCoroutine(LoadNextScene());
        player.transform.position = Vector2.zero;
    }

    public void PreviousScene() {
        StartCoroutine(LoadPreviousScene());
        //player.transform.position = new Vector2((float)25.1, (float)29.74);
    }

    // credit to rehope games for this coroutine.
    IEnumerator LoadNextScene() {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        sceneTransition.SetTrigger("Start");
    }

    IEnumerator LoadPreviousScene() {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex-1);
        sceneTransition.SetTrigger("Start");
    }

}

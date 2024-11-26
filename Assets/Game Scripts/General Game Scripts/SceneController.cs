using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{


    // This is supposed to be a scene manager, however, for demo sake I will simply teleport
    // the player to another position. This can dynamically transition from scene to scene however.

    [SerializeField] private AudioSource doorOpen;
    [SerializeField] private AudioSource doorClose;
    public Animator sceneTransition;
    public static SceneController instance;
    public Player_Movement player;
    private Vector2 StorePlayerLocation = Vector2.zero;
    //private GameData gameData = new GameData();

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        gameObject.SetActive(true);
    }

    public void EnterExitHouse(Vector2 pos)
    {
        StorePlayerLocation = pos;
        doorOpen.Play();
        StartCoroutine(LoadHouse());
    }
    public void EnterCustomScene(string sceneName)
    {
        StartCoroutine(LoadSpecificScene(sceneName));
    }
    // credit to rehope games for this coroutine.
    IEnumerator LoadHouse()
    {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        player.transform.position = StorePlayerLocation;
        sceneTransition.SetTrigger("Start");
        doorClose.Play();
    }

    IEnumerator LoadSpecificScene(string sceneName)
    {
        sceneTransition.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        sceneTransition.SetTrigger("Start");
    }

}

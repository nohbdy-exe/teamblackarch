using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;
public class PlayerAutoMovement : MonoBehaviour
{
    public bool battleSceneStarting;
    protected Vector2 desiredPosition;
    protected float speed = 3f;
    public Player_Movement playerMovement;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "BattleScene")
        {
            battleSceneStarting = true;
            Debug.Log("Battle Scene Starting");
            flipCharacter();
        }
        else
        {
            battleSceneStarting = false;
        }
    }
    public void UpdateAnimation()
    {
        if (battleSceneStarting)
        {

            animator.SetBool("BattleIsStarting", true);

        }
        else
        {
            animator.SetBool("BattleIsStarting", false);
        }

    }
    public void flipCharacter()
    {
        this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        if (this.transform.position.x >= -5)
        {
            animator.SetBool("BattleIsStarting", false);
            animator.SetBool("PlayerReachedPosition", false);
        }
    }
}
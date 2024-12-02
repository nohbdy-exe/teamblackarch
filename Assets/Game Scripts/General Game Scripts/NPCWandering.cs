using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class NPCWandering : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float npcSpeed;
    [SerializeField] private float npcPauseTime;
    [SerializeField] private Animator npcAnim;
    public Dialog npcDialog;
    public string npcCharacterName;
    [SerializeField] private SpriteRenderer npcSpriteRenderer;
    public Player_Movement player;
    private int currentWaypointIndex = 0;
    private bool isMovingForward = true;
    private Rigidbody2D rb;
    private bool playerInRange = false;
    private Coroutine wanderCoroutine;
    private bool questGiven;
    [SerializeField] private TMP_Text questTitle;
    [SerializeField] private TMP_Text questDescription;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        playerInRange = false;
        questGiven = false;
        if (waypoints.Length > 0)
        {
            wanderCoroutine = StartCoroutine(NPCWander());
        }
        else
        {
            Debug.Log("Wander waypoints empty, please attach waypoints to the NPC object.");
        }
    }

    public bool GetPlayerInRange()
    {
        return this.playerInRange;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();
        CheckOrderLayer();
    }

    void CheckOrderLayer()
    {
        if (player.transform.position.y >= transform.position.y)
        {
            npcSpriteRenderer.sortingOrder = 1;
        }
        else
        {
            npcSpriteRenderer.sortingOrder = -1;
        }
    }

    public bool IfNPCVelocityZero()
    {
        if(rb.velocity == Vector2.zero)
        {
            return true;
        }
        else { return false; }
    }

    void UpdateAnimation()
    {
        if (rb.velocity != Vector2.zero)
        {
            npcAnim.SetBool("Walking", true);
            npcAnim.SetFloat("Horizontal", rb.velocity.x);
            npcAnim.SetFloat("Vertical", rb.velocity.y);

            GetComponent<SpriteRenderer>().flipX = rb.velocity.x > 0;
        }
        else
        {
            npcAnim.SetBool("Walking", false);
        }
    }

    private IEnumerator NPCWander()
    {
        while (true)
        {
            yield return StartCoroutine(MoveToWaypoint(waypoints[currentWaypointIndex]));
            yield return new WaitForSeconds(npcPauseTime);

            if (isMovingForward)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 2;
                    isMovingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;

                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    isMovingForward = true;
                }
            }
        }
    }

    private IEnumerator MoveToWaypoint(Transform waypoint)
    {
       float posThreshold = 0.05f;

       while (Vector2.Distance((Vector2)rb.position,(Vector2) waypoint.position)>posThreshold)
        {
            // Move NPC towards the target waypoint using Rigidbody2D
            Vector2 direction = ((Vector2) waypoint.position - (Vector2) rb.position).normalized;  // Calculate direction to the target

            rb.velocity = direction * npcSpeed; // move towards target

            // Wait for the next frame
            yield return null;
        }

       rb.position = waypoint.position;
       rb.velocity = Vector2.zero;
    }

    // Trigger when player enters or exits the range of the NPC
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.playerInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            this.playerInRange = false;
            StopCoroutine(DialogManager.Instance.ShowDialog(npcDialog, npcCharacterName));
            ResumeWanderingAfterDialog();
        }
    }

    public void TalkToNPC()
    {
        if (wanderCoroutine != null)
        {
            StopCoroutine(wanderCoroutine);
            wanderCoroutine = null;
        }

        rb.velocity = Vector2.zero;
        StartCoroutine(DialogManager.Instance.ShowDialog(npcDialog, npcCharacterName));
    }

    public void ResumeWanderingAfterDialog()
    {
        if (wanderCoroutine == null)
        {
            wanderCoroutine = StartCoroutine(NPCWander());
        }
    }

    /*
    public void CreateQuest(string qTitle, string qDesc)
    {
        if (DialogManager.Instance.dialogDone && questGiven == false)
        {
            this.questGiven = true;
            this.questTitle.text = qTitle;
            this.questDescription.text = qDesc;
        }
    }
    */

}

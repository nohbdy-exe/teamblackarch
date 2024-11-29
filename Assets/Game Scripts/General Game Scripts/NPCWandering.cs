using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NPCWandering : MonoBehaviour
{
    [Header("Waypoints")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float npcSpeed;
    [SerializeField] private float npcPauseTime;
    [SerializeField] private Animator npcAnim;
    [SerializeField] private Dialog npcDialog;
    [SerializeField] private string npcCharacterName;
    public Player_Movement player;
    private int currentWaypointIndex = 0;
    private bool isMovingForward = true;
    private Rigidbody2D rb;
    private bool playerInRange = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (waypoints.Length > 0)
        {
            StartCoroutine(NPCWander());
        }
        else
        {
            Debug.Log("Wander waypoints empty, please attach waypoints to the NPC object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player pressed E");
            StartCoroutine(HandleDialog());
        }
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

    private IEnumerator HandleDialog()
    {
        Debug.Log("Dialog ended, resuming NPC wandering.");
        rb.velocity = Vector2.zero;
        DialogManager.Instance.ShowDialog(npcDialog, npcCharacterName);
        yield return StartCoroutine(NPCWander());
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
                    isMovingForward=true;
                }
            }
        }
    }

    private IEnumerator MoveToWaypoint(Transform waypoint)
    {
       float posThreshold = 0.1f;

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
            Debug.Log("Player triggered");
            playerInRange = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] Dialog dialog;
    private bool isPlayerInRange = false;

    void Update()
    {
        // Check if player is in range and presses a key to interact
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            TriggerNPCDialog();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player entered the trigger
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void TriggerNPCDialog()
    {
        /*if (npcDialog == null || npcDialog.dialogLines == null || npcDialog.dialogLines.Count == 0)
        {
            Debug.LogError("NPC dialog is null or improperly configured");
            return;
        } */
        Debug.Log("NPC dialog triggered");
        Player_Movement playerMovement = FindObjectOfType<Player_Movement>();
        playerMovement.TriggerDialog(dialog);
    }
}
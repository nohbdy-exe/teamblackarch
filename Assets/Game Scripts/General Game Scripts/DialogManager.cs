using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;
    [SerializeField] int typeSpeed;

    Dialog dialog;
    int currentLine;
    bool isTyping;
    bool isDialogActive;

    private float inputCooldown = 0.2f;
    private float inputTimer = 0f;
   
    public event Action OnShowDialog;
    public event Action OnHideDialog;

    public static DialogManager Instance { get; private set; }

    // awake is before start
    private void Awake() {
        Instance = this;
        dialogBox.SetActive(false);
    }

    // start dialog process when triggered by player_movement or NPC
    public void StartDialog(Dialog dialog)
    {
        if(dialog == null || dialog.dialogLines == null || dialog.dialogLines.Count == 0){
            Debug.LogError("dialog is null or improperly configured");
            return;
        }
       
        this.dialog = dialog; // sets dialog
        currentLine = 0; // starts from first line
        isDialogActive = true; 
        dialogBox.SetActive(true);
        
        Debug.Log("starting NPC dialog");
        Debug.Log("Dialog has " + dialog.dialogLines.Count + " lines.");
        
        OnShowDialog?.Invoke(); // trigger dialog event    
        StartCoroutine(TypeDialog(dialog.dialogLines[currentLine])); // start typing first line
    }
 
    // Call in GameStateManager
    public void Update() {
        if (isDialogActive && !isTyping && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player pressed E");
            AdvanceDialog();
            inputTimer = inputCooldown;
        }
        inputTimer -= Time.deltaTime;
    }

    private void AdvanceDialog()
    {
        if(isTyping){
            Debug.Log("still typing, wait for current line to finish.");
            return;
        }
        
        currentLine++;
        Debug.Log($"Advancing to line {currentLine}");
        
        if (currentLine < dialog.dialogLines.Count)
        {
            Debug.Log($"Starting to type line {currentLine}: {dialog.dialogLines[currentLine]}");
            StartCoroutine(TypeDialog(dialog.dialogLines[currentLine]));
        }
        else
        {
            Debug.Log("No more lines, ending dialog");
            EndDialog();
        }
    }

    private void EndDialog()
    {
        dialogBox.SetActive(false);
        isDialogActive = false;
        OnHideDialog?.Invoke();
        Debug.Log("dialog ended.");
    }

    // coroutine to run through dialog lines by letter
    public IEnumerator TypeDialog(string dline) {
        isTyping = true;
        dialogText.text = "";
        
        foreach (var letter in dline.ToCharArray()) {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / typeSpeed);
        }
        isTyping = false;
        Debug.Log("Typing complete for current line:" + dline);
    }
}

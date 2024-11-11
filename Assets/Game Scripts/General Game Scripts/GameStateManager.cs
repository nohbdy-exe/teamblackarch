using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create enumerator GameState
public enum GameState {Main,Dialog}

public class GameManager : MonoBehaviour
{

    [SerializeField] Player_Movement player;
    GameState state;

   private void Start() {
        // Lambda functions
        DialogManager.Instance.OnShowDialog += () => {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnHideDialog += () => {
            if (state == GameState.Dialog) { state = GameState.Main; }
        };
    }

    private void Update() {
        if (state == GameState.Main) {
            player.PlayerUpdate();
        } else if (state == GameState.Dialog) {
            DialogManager.Instance.DialogUpdate();
        }
    }


}

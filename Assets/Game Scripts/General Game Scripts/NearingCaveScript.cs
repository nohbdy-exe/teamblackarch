using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearingCaveAutoSaveScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Check for a match with the specific tag on any GameObject that collides with your GameObject
        if (other.gameObject.tag == "Player")
        {
            DataPersistenceManager.Instance.SaveGame();
            Debug.Log("Autosaving");
        }
    }
    
}

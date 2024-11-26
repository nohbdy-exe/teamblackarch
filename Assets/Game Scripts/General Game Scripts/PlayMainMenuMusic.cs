using UnityEngine;

public class PlayMainMenuMusic : MonoBehaviour
{
    private void Awake()
    {
        // Ensure the music is played only once by checking if an instance exists
        if (FindObjectOfType<PlayMainMenuMusic>() == null)
        {
            // Play the music
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            // If a background music instance already exists, destroy this one to avoid duplicates
            Destroy(gameObject);
        }

        // Don't destroy the music on scene load
        DontDestroyOnLoad(gameObject);
    }
}
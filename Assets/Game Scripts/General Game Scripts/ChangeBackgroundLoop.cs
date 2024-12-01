using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundLoop : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip islandLoop;
    public AudioClip houseLoop;
    public AudioClip caveLoop;
    private AudioClip currentClip;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        currentClip = islandLoop;
        audioSource.clip = currentClip;
        audioSource.Play();
    }

    private void Update()
    {
        if (transform.position.x < -60 && currentClip != caveLoop) {
            PlayMusic(caveLoop);
        }

        if (transform.position.y > 70 && currentClip != houseLoop)
        {
            PlayMusic(houseLoop);
        }

        if (transform.position.x >= -60 && transform.position.y <= 70 && currentClip != islandLoop)
        {
            PlayMusic(islandLoop);
        }
    }

    void PlayMusic(AudioClip newClip)
    {
        // Only change the clip and play if the clip is different
        if (audioSource.clip != newClip)
        {
            audioSource.clip = newClip;
            audioSource.Play();
        }
    }
}

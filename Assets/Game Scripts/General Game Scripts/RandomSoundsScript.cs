using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundsScript : MonoBehaviour
{
    public AudioSource randomSound;
    public AudioClip[] audioSources;
    private bool isWalking = false;
    [SerializeField] private float walkInterval = 0.5f;

    private void Start()
    {
        randomSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.1f)
        {
            if (!isWalking)
            {
                isWalking = true;
                StartWalkingSounds();
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                StopWalkingSounds();
            }
        }
    }
    
    void StartWalkingSounds()
    {
        InvokeRepeating("PlayRandomSound", 0f, walkInterval);
    }

    void StopWalkingSounds()
    {
        CancelInvoke("PlayRandomSound");
    }

    void PlayRandomSound()
    {
        if (audioSources.Length > 0)
        {
            int randomIndex = Random.Range(0, audioSources.Length);
            randomSound.PlayOneShot(audioSources[randomIndex]);
        }
    }

}

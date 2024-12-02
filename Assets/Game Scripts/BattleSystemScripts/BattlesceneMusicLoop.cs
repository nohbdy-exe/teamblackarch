using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattlesceneMusicLoop : MonoBehaviour
{
    [SerializeField] public AudioSource audioSource;
    bool isMuted = false;
    [SerializeField] public Button muteButton;
    [SerializeField] public Sprite VolumeUnmute;
    [SerializeField] public Sprite VolumeMute;

    public void MuteUnmuteMusic()
    {
        if (isMuted == false)
        {
            audioSource.volume = 0;
            isMuted = true;
            muteButton.image.sprite = VolumeMute;
        }
        if (isMuted == true)
        {
            audioSource.volume = 1;
            isMuted = false;
            muteButton.image.sprite = VolumeUnmute;
        }
    }
}

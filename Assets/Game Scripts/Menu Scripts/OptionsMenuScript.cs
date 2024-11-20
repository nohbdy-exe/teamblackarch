using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Linq.Expressions;


public class OptionsMenuScript : MonoBehaviour
{
    public PlayerData playerInfo;
    public bool musicMuted = false;
    public bool sfxMuted = false;
    public float musicVolume=1;
    public float sfxVolume=1;
    private float prvsMusicVolume;
    private float prvsSfxVolume;
    public GameObject pauseUI;
    public GameObject optionUI;
    [SerializeField] public Slider musicSlider;
    [SerializeField] public Slider sfxSlider;
    [SerializeField] public Button btnMusic;
    [SerializeField] public Button btnSFX;
    [SerializeField] public Sprite VolumeUnmute;
    [SerializeField] public Sprite VolumeMute;
    public void Start()
    {
        musicSlider.value = 1; sfxSlider.value = 1;
    }
    public void MusicButtonPressed()
    {
        if (musicMuted)
        {
            if (prvsMusicVolume !=0)
            {
                musicSlider.value = prvsMusicVolume;
            }
            musicMuted = false;
            musicVolume = musicSlider.value;
            btnMusic.image.sprite = VolumeUnmute;
        }
        else if (!musicMuted)
        {
            musicMuted = true;
            prvsMusicVolume = musicSlider.value;
            musicVolume = 0;
            musicSlider.value = 0;
            btnMusic.image.sprite = VolumeMute;
        }
       
    }
    public void SFXButtonPressed()
    {
        if (sfxMuted)
        {
            if (prvsSfxVolume!=0)
            {
                sfxSlider.value = prvsSfxVolume;
            }
            sfxMuted = false;
            sfxVolume = sfxSlider.value;
            btnSFX.image.sprite = VolumeUnmute;
        }
        else if (!sfxMuted)
        {
            sfxMuted = true;
            prvsSfxVolume = sfxSlider.value;
            sfxVolume = 0;
            sfxSlider.value = 0;
            btnSFX.image.sprite = VolumeMute;
        }
    }
    public void MusicVolumeChanged()
    {
        if (musicSlider.value != 0)
        {
            musicMuted = false;
            musicVolume = musicSlider.value;
            btnMusic.image.sprite = VolumeUnmute;
        }
        else if (musicSlider.value == 0)
        {
            musicVolume = 0;
            btnMusic.image.sprite = VolumeMute;
            musicMuted = true;
        }
        
    }
    public void SfxVolumeChanged()
    {
        if (sfxSlider.value != 0)
        {
            sfxMuted = false;
            btnSFX.image.sprite = VolumeUnmute;
            sfxVolume = sfxSlider.value;
        }
        else if (sfxSlider.value == 0)
        {
            sfxVolume = 0;
            btnSFX.image.sprite = VolumeMute;
            sfxMuted = true;
        }
        
    }
    public void returnButtonPressed()
    {
        optionUI.SetActive(false);
        pauseUI.SetActive(true);
        updateAudioScripts();
    }
    public void updateAudioScripts()
    {
        //Need to find a way to update the volume in the other scripts that use audio files.
    }





}

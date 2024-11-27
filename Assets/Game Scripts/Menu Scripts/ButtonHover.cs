using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    private AudioSource audioSource;
    public AudioClip hoverSound;
    public AudioClip pressedSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(hoverSound);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (pressedSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pressedSound);
        }
    }
}

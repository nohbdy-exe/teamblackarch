using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectFadeInOutEffect : MonoBehaviour
{
    private CanvasGroup gameobjectCanvas;
    [SerializeField] private float fadeDuration = 0.5f;

    private void Start()
    {
        gameobjectCanvas = GetComponent<CanvasGroup>();

        if (gameobjectCanvas == null)
        {
            gameobjectCanvas = gameObject.AddComponent<CanvasGroup>();
        }

        gameobjectCanvas.alpha = 0;
    }

    private void OnEnable()
    {
        StartCoroutine(DelayOneFrame());
    }

    private void OnDisable()
    {
        StartCoroutine (FadeOutEffect());
    }

    private IEnumerator FadeInEffect()
    {
        float dur = 0f;
        while (dur < fadeDuration)
        {
            gameobjectCanvas.alpha = Mathf.Lerp(0,1,dur/fadeDuration);
            dur += Time.deltaTime;
            yield return null;
            // Slowly fades in the button with Time.deltaTime and mathf.lerp.
        }
        gameobjectCanvas.alpha = 1f; // Visible at end.
    }

    private IEnumerator FadeOutEffect()
    {
        float dur = 0f;
        while (dur < fadeDuration)
        {
            gameobjectCanvas.alpha = Mathf.Lerp(1, 0, dur / fadeDuration);
            dur += Time.deltaTime;
            yield return null;
            // Slowly fades out the button.
        }
        gameobjectCanvas.alpha = 0f; // Ensure its invisible.
    }

    private IEnumerator DelayOneFrame()
    {
        yield return null;

        StartCoroutine (FadeInEffect());
    }


}

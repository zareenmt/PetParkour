using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject optionsOverlay;
    public AnimationCurve animationCurve;
    private Vector3 hiddenPosition = new Vector3(0, 1800, 0);
    private Vector3 visiblePosition = new Vector3(0, 0, 0);
    public float animationDuration = 1f;

    public CanvasGroup fadePanel;
    public float fadeDuration = 1f;

    private Coroutine animationCoroutine;

    public Slider volumeSlider;
    private AudioSource backgroundMusicSource;

    private void Start() {
        optionsOverlay.transform.localPosition = hiddenPosition;
        fadePanel.alpha = 0f;

        if (volumeSlider != null) {
            BackgroundMusicManager musicManager = FindObjectOfType<BackgroundMusicManager>();
            if (musicManager != null) {
                float currentVolume = musicManager.GetVolume();
                volumeSlider.value = currentVolume; // Initialize slider to current volume
                volumeSlider.onValueChanged.AddListener(SetVolume);
            }
        }
    }

    public void onPlayButton() {
        StartCoroutine(FadeScene(1));
    }
    
    public void onExitButton() {
        Application.Quit();
    }

    public void onOptionsButtonOpen() {
        animationCoroutine = StartCoroutine(AnimateOverlay(hiddenPosition, visiblePosition));
    }

    public void onOptionsButtonClose() {
        animationCoroutine = StartCoroutine(AnimateOverlay(visiblePosition, hiddenPosition));
    }

    private IEnumerator AnimateOverlay(Vector3 start, Vector3 end) {
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration) {
            float t = elapsedTime / animationDuration;
            float curveValue = animationCurve.Evaluate(t);
            optionsOverlay.transform.localPosition = Vector3.Lerp(start, end, curveValue);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator FadeScene(int scene) {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration) {
            float t = elapsedTime / fadeDuration;
            fadePanel.alpha = t;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(scene);
    }

    public void SetVolume(float volume) {
        BackgroundMusicManager musicManager = FindObjectOfType<BackgroundMusicManager>();

        if (musicManager != null) {
            musicManager.SetVolume(volume);
        }
    }
}
